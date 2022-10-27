using BoostIK.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.UI.Utils
{
    public class ClaimService
    {
        private readonly UserManager<Personel> userManager;

        public ClaimService(UserManager<Personel> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<bool> AddClaimsToUser(Personel user)
        {
            await userManager.AddClaimAsync(user, new Claim("userId", user.Id));
            await userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
            await userManager.AddClaimAsync(user, new Claim("photoPath", user.ImagePath));

            return true;
        }

        public async Task<bool> RemoveClaims(Personel user)
        {
            await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));
            return true;
        }

        public async Task<bool> ReplaceClaims(Personel user)
        {
            await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));
            await userManager.AddClaimAsync(user, new Claim("userId", user.Id));
            await userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
            await userManager.AddClaimAsync(user, new Claim("photoPath", user.ImagePath));
            //await RemoveClaims(user);
            //await AddClaimsToUser(user);
            return true;
        }
    }
}

