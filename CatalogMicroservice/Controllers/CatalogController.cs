using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogMicroservice.Database;
using CatalogMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        DatabaseContext db;
        public CatalogController(DatabaseContext _db)
        {
            db = _db;
        }

        [HttpGet("serviceTypes")]
        public IActionResult GetServiceTypes()
        {
            var data = db.ServiceTypes.Select(s => new { s.ServiceTypeId, s.Description }).ToList();
            return Ok(data);
        }

        [HttpGet("attentionModes")]
        public IActionResult GetAttentionModes()
        {
            var data = db.AttentionModes.Select(a => new { a.AttentionModeId, a.Description }).ToList();
            return Ok(data);
        }

        [HttpGet("campus")]
        public IActionResult GetCampus()
        {
            var data = db.Campus.Select(a => new { a.CampusId, a.Description }).ToList();
            return Ok(data);
        }

        [HttpGet("knowledgeBase")]
        public IActionResult GetKnowledgeBase()
        {
            List<KnowledgeBaseModel> data = new List<KnowledgeBaseModel>();
            data = (from kb in db.KnowledgeBase
                    join st in db.ServiceTypes
                    on kb.ServiceTypeId equals st.ServiceTypeId                                       
                    select new KnowledgeBaseModel
                    {
                        ServiceTypeDescription = st.Description,
                        Question = kb.Question,
                        Answer = kb.Answer,
                        InquiriesQuantity = kb.InquiriesQuantity
                    }).OrderByDescending(kb => kb.InquiriesQuantity)
                    .ToList();            
            return Ok(data);
        }
    }
}