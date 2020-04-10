﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SecureBank.Ctf;
using SecureBank.Ctf.Models;
using SecureBank.Models;
using SecureBank.Models.Store;
using SecureBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBank.Ctf.Services
{
    public class CtfAdminStoreBL : AdminStoreBL
    {
        private readonly CtfOptions _ctfOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CtfAdminStoreBL(StoreAPICalls storeAPICalls, IOptions<CtfOptions> ctfOptions, IHttpContextAccessor httpContextAccessor) : base(storeAPICalls)
        {
            _ctfOptions = ctfOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<DataTableResp<StoreItem>> GetStoreItems()
        {
            DataTableResp<StoreItem> storeItems = await base.GetStoreItems();

            bool xss = storeItems.Data.Any(x => CtfConstants.XXS_KEYVORDS.Any(c => (x.Name?.Contains(c) ?? false) || (x.Description?.Contains(c) ?? false)));
            if (xss)
            {
                CtfChallangeModel xxsChallange = _ctfOptions.CtfChallanges
                    .Where(x => x.Type == CtfChallengeTypes.Xss)
                    .Single();

                _httpContextAccessor.HttpContext.Response.Headers.Add(xxsChallange.FlagKey, xxsChallange.Flag);
            }

            return storeItems;
        }

        public override async Task<List<PurcahseHistoryItemResp>> GetAllPurchases()
        {
            List<PurcahseHistoryItemResp> purchases = await base.GetAllPurchases();

            bool xss = purchases.Any(x => CtfConstants.XXS_KEYVORDS.Any(c => (x.Name?.Contains(c) ?? false) || (x.Description?.Contains(c) ?? false)));
            if (xss)
            {
                CtfChallangeModel xxsChallange = _ctfOptions.CtfChallanges
                    .Where(x => x.Type == CtfChallengeTypes.Xss)
                    .Single();

                _httpContextAccessor.HttpContext.Response.Headers.Add(xxsChallange.FlagKey, xxsChallange.Flag);
            }

            return purchases;
        }
    }
}