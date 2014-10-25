using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages.Usuario;
using SecondFloor.Infrastructure;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

namespace SecondFloor.Web.Mvc.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.Title = "Login de Usuario";

            ViewBag.ReturnUrl = returnUrl;

            return View("UsuarioLogin");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel usuario, string returnUrl)
        {
            var request = new EncontrarUsuarioRequest() { Usuario = usuario.ConvertToUsuarioDto()};
            var response = _usuarioService.EncontrarUsuarioPor(request);

            ViewBag.Title = "Login de Usuario";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value));

                return View("UsuarioLogin");
            }

            //seta o Cookie
            FormsAuthentication.SetAuthCookie(usuario.Email, usuario.RememberMe);

            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}