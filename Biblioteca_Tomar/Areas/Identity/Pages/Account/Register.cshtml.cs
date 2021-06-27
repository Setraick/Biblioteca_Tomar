using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Biblioteca_Tomar.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Biblioteca_Tomar.Models;

namespace Biblioteca_Tomar.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// referência à BD do nosso sistema
        /// </summary>
        private readonly ApplicationDbContext _context;


        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="logger"></param>
        /// <param name="emailSender"></param>
        
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        /// <summary>
        /// model usado para 'transportar' os dados para a interface de 'registar'
        /// </summary>
        [BindProperty] // garante a exitencia de memoria entre o model e a interface
        public InputModel Input { get; set; }

        /// <summary>
        /// serve para redirecionar o utilizador para o 'local' de origem
        /// </summary>
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// classe usada para 'transportar/recolher' os dados da pagina para dentro do 'codigo'
        /// </summary>
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "A password e a sua confirmação não coincidem.")]
            public string ConfirmPassword { get; set; }
            /// <summary>
            /// Ao anexar um objeto deste tipo ao 'InputModel' estamos a permitir a recolha dos dados do utilizador
            /// </summary>
            public Utilizadores Utilizador { get; set; }
        }

        /// <summary>
        /// método a ser executado pela página , quando o http é invocado em get
        /// </summary>
        /// <param name="returnUrl">link para redirecioinar o utilizador, se fornecido</param>
        /// <returns></returns>
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            //lista dos 'providers' para efetuar autenticação externa
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        /// <summary>
        /// método a ser executado pela página , quando o http é invocado em post
        ///     criar um novo utilizador
        ///     registar os dados pessoais do utilizador
        /// </summary>
        /// <param name="returnUrl">link para redirecioinar o utilizador, se fornecido</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //não é necessário especificar uma variável de adição de dados da 'view'
            //a este metodo porque essa variavel ja esta previamene definida no
            //atributo 'input' 
            //        public InputModel Input { get; set; }

            //se o 'returnUrl' for null, é-lhe atribuido um url
            //se não for null nada é feito
            returnUrl ??= Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            //validar se se pode criar um user
            //se os dados forem validados pela classe 'InputModel'
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                // criar um objeto do tipo 'applicationUser'
                var user = new ApplicationUser
                {
                    UserName = Input.Email, //username
                    Email = Input.Email, //e-mail do utilizador
                    EmailConfirmed = false, //o e-mail ´~ao está formálmente confirmado
                    LockoutEnabled = true, //o utilizador pode ser bloqueado
                    LockoutEnd = new DateTime(DateTime.Now.Year + 10, 1, 1), // data em que termina o bloqueio, se não for anulado antes
                    DataRegisto = DateTime.Now // data do registo 

                };

                // tentativa de criar esse utilizador
                var result = await _userManager.CreateAsync(user, Input.Password);

                //se houver sucesso 
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //se se desejar associar o utilizador recém criado ao role 'Admninistrador'

                    //*****************************************************************
                    //vamos proceder à operação de guardar os dados do Utilizador
                    //*****************************************************************
                    //preparar os dados do Utilizador para serem adicionados à BD
                    Input.Utilizador.Email = Input.Email; // atribuir ao objeto 'Utilizador' o email fornecido pelo utilizador,
                                                          // a quando a escrita dos dados na interface

                    Input.Utilizador.UserId = user.Id;

                    //estamos em condições de guardar os dados na BD
                    try
                    {
                        _context.Add(Input.Utilizador); //Adicionar o Utilizador

                        //throw new Exception();

                        await _context.SaveChangesAsync();// 'commit' da adição1
                        // Enviar para o utilizador para a página de confirmação da criação de Registo
                        return RedirectToPage("RegisterConfirmation");
                    }
                    catch (Exception)
                    {
                        //houve um erro na criação dos dados do utilizador
                        //Mas o user ja foi criado na BD
                        //efetuar o rollback da ação
                        await _userManager.DeleteAsync(user);

                        //avisar que houve um erro
                        ModelState.AddModelError("", "Ocorreu um erro na criação de dados.");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
