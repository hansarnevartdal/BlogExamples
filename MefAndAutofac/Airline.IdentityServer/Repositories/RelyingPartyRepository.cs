using System;
using System.Collections.Generic;
using Thinktecture.IdentityServer.Models;
using Thinktecture.IdentityServer.Repositories;

namespace Airline.IdentityServer.Repositories
{
    class RelyingPartyRepository : IRelyingPartyRepository
    {
        public void Add(RelyingParty relyingParty)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public RelyingParty Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RelyingParty> List(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool SupportsWriteAccess
        {
            get { throw new NotImplementedException(); }
        }

        public bool TryGet(string realm, out RelyingParty relyingParty)
        {
            relyingParty = new RelyingParty
            {
                Enabled = true,
                Realm = new Uri(realm),
                Name = "Oceanic Airline",
                SymmetricSigningKey = Convert.FromBase64String("L6aMge6UHG5IJ+Ah10Nhw9wsmkWC9ZBUEHT2lciAwSw=")
            };

            return true;
        }

        public void Update(RelyingParty relyingParty)
        {
            throw new NotImplementedException();
        }
    }
}
