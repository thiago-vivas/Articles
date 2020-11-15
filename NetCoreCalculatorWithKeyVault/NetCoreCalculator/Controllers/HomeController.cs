using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using NetCoreCalculator.Business;
using NetCoreCalculator.Models;

namespace NetCoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly string keyVaultURI = "https://azurekeyvaultsampletwo.vault.azure.net/";

        private readonly string clientAppID = "";

        private readonly string clientAppSecret = "";


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClientCredential credential = new ClientCredential(clientAppID, clientAppSecret);
            KeyVaultClient.AuthenticationCallback authenticationCallback = new
                KeyVaultClient.AuthenticationCallback(async
                (string authenticationAuthority, string resource, string scope) =>
            {
                AuthenticationContext authenticationContext = new AuthenticationContext(authenticationAuthority);
                AuthenticationResult result = await authenticationContext.AcquireTokenAsync(resource, credential);
                return result.AccessToken;
            });
            KeyVaultClient client = new KeyVaultClient(authenticationCallback);
            var secret = await client.GetSecretAsync(keyVaultURI, "sampleSecret");

            ViewBag.Secret = secret.Value;

            return View();
        }

        [HttpPost]
        public IActionResult Index(Operation model)
        {
            if (model.OperationType == OperationType.Addition)
                model.Result = model.NumberA + model.NumberB;
            return View(model);
        }

        [HttpPost]
        public IActionResult CompoundInterest(CompoundInterestModel model)
        {
            model.Result = Calculation.CalculateCompoundInterest(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult CompoundInterest()
        {
            return View();
        }
    }
}