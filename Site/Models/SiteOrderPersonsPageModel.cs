using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Site.Data;

namespace Site.Models
{
    public class SiteOrderPersonsPageModel : PageModel
    {
        public List<AssignedPersonalizationData> AssignedPersonalizationDataList;
        public void PopulateAssignedPersonalizationData(SiteContext context,
        SiteOrder siteorder)
        {
            var allPersonalizations = context.Personalization;
            var siteorderpersons = new HashSet<int>(siteorder.SiteOrderPersons.Select(c => c.PersonalizationID)); 
            AssignedPersonalizationDataList = new List<AssignedPersonalizationData>();
            foreach (var per in allPersonalizations)
            {
                AssignedPersonalizationDataList.Add(new AssignedPersonalizationData
                {
                    PersonalizationID = per.ID,
                    Name = per.NumePersonalizare,
                    Assigned = siteorderpersons.Contains(per.ID)
                });
            }
        }
        public void UpdateSiteOrderPersons(SiteContext context,
        string[] selectedPersonalizations, SiteOrder siteorderToUpdate)
        {
            if (selectedPersonalizations == null)
            {
                siteorderToUpdate.SiteOrderPersons = new List<SiteOrderPerson>();
                return;
            }

            var selectedPersonalizationsHS = new HashSet<string>(selectedPersonalizations);
            var siteorderpersons = new HashSet<int>
            (siteorderToUpdate.SiteOrderPersons.Select(c => c.Personalization.ID));
            foreach (var per in context.Personalization)
            {
                if (selectedPersonalizationsHS.Contains(per.ID.ToString()))
                {
                    if (!siteorderpersons.Contains(per.ID))
                    {
                        siteorderToUpdate.SiteOrderPersons.Add(
                        new SiteOrderPerson
                        {
                            SiteOrderComandaSiteId = siteorderToUpdate.ComandaSiteId,
                            PersonalizationID = per.ID
                        });
                    }
                }
                else
                {
                    if (siteorderpersons.Contains(per.ID))
                    {
                        SiteOrderPerson courseToRemove
                        = siteorderToUpdate
                        .SiteOrderPersons
                       .SingleOrDefault(i => i.PersonalizationID == per.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
