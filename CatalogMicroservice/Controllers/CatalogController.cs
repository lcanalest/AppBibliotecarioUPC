using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        /* Service Types */
        [HttpGet("lstServiceTypes")]
        public IActionResult GetServiceTypes()
        {
            var data = db.ServiceTypes.Select(s => new { s.ServiceTypeId, s.Description }).ToList();
            return Ok(data);
        }

        [HttpPost("crtServiceType")]
        // Parámetros que se deben enviar en el body-request: CreateServiceTypeModel => Description y CreationUser
        public void CreateServiceType(CreateServiceTypeModel model)
        {
            ServiceType serviceType = new ServiceType
            {
                Description = model.Description,
                CreationDate = DateTime.Now,
                CreationUser = model.CreationUser
            };

            db.ServiceTypes.Add(serviceType);
            db.SaveChanges();
        }

        [HttpDelete("dltServiceType")]
        // Parámetros que se deben enviar en el body-request: DeleteServiceTypeModel => ServiceTypeId
        public void DeleteServiceType(DeleteServiceTypeModel model)
        {
            db.Remove(db.ServiceTypes.Single(st => st.ServiceTypeId == model.ServiceTypeId));
            db.SaveChanges();
        }

        [HttpPut("updServiceType")]
        // Parámetros que se deben enviar en el body-request: UpdateServiceTypeModel => ServiceTypeId, Description y CreationUser
        public void UpdateServiceType(UpdateServiceTypeModel model)
        {
            var serviceType = db.ServiceTypes.First(st => st.ServiceTypeId == model.ServiceTypeId);

            serviceType.Description = model.Description;
            serviceType.CreationUser = model.CreationUser;
            serviceType.CreationDate = DateTime.Now;

            db.SaveChanges();
        }

        /* Attention Modes */
        [HttpGet("lstAttentionModes")]
        public IActionResult GetAttentionModes()
        {
            var data = db.AttentionModes.Select(a => new { a.AttentionModeId, a.Description }).ToList();
            return Ok(data);
        }

        [HttpPost("crtAttentionMode")]
        // Parámetros que se deben enviar en el body-request: CreateAttentionModeModel => Description y CreationUser
        public void CreateAttentionMode(CreateAttentionModeModel model)
        {
            AttentionMode attentionMode = new AttentionMode
            {
                Description = model.Description,
                CreationDate = DateTime.Now,
                CreationUser = model.CreationUser
            };

            db.AttentionModes.Add(attentionMode);
            db.SaveChanges();
        }

        [HttpDelete("dltAttentionMode")]
        // Parámetros que se deben enviar en el body-request: DeleteAttentionModeModel => AttentionModeId
        public void DeleteAttentionMode(DeleteAttentionModeModel model)
        {
            db.Remove(db.AttentionModes.Single(am => am.AttentionModeId == model.AttentionModeId));
            db.SaveChanges();
        }

        [HttpPut("updAttentionMode")]
        // Parámetros que se deben enviar en el body-request: UpdateAttentionModeModel => AttentionModeId, Description y CreationUser
        public void UpdateAttentionMode(UpdateAttentionModeModel model)
        {
            var attentionMode = db.AttentionModes.First(am => am.AttentionModeId == model.AttentionModeId);

            attentionMode.Description = model.Description;
            attentionMode.CreationUser = model.CreationUser;
            attentionMode.CreationDate = DateTime.Now;

            db.SaveChanges();
        }

        /* Campus */
        [HttpGet("lstCampus")]
        public IActionResult GetCampus()
        {
            var data = db.Campus.Select(a => new { a.CampusId, a.Description }).ToList();
            return Ok(data);
        }

        [HttpPost("crtCampus")]
        // Parámetros que se deben enviar en el body-request: CreateCampusModel => Description y CreationUser
        public void CreateCampus(CreateCampusModel model)
        {
            Campus campus = new Campus
            {
                Description = model.Description,
                CreationDate = DateTime.Now,
                CreationUser = model.CreationUser
            };

            db.Campus.Add(campus);
            db.SaveChanges();
        }

        [HttpDelete("dltCampus")]
        // Parámetros que se deben enviar en el body-request: DeleteCampusModel => CampusId
        public void DeleteCampus(DeleteCampusModel model)
        {
            db.Remove(db.Campus.Single(c => c.CampusId == model.CampusId));
            db.SaveChanges();
        }

        [HttpPut("updCampus")]
        // Parámetros que se deben enviar en el body-request: UpdateCampusModel => CampusId, Description y CreationUser
        public void UpdateCampus(UpdateCampusModel model)
        {
            var campus = db.Campus.First(c => c.CampusId == model.CampusId);

            campus.Description = model.Description;
            campus.CreationUser = model.CreationUser;
            campus.CreationDate = DateTime.Now;

            db.SaveChanges();
        }

        /* Knowledge Base */
        [HttpGet("lstKnowledgeBase")]
        public IActionResult GetKnowledgeBase()
        {
            List<ListKnowledgeBaseModel> data = new List<ListKnowledgeBaseModel>();
            data = (from kb in db.KnowledgeBase
                    join st in db.ServiceTypes
                    on kb.ServiceTypeId equals st.ServiceTypeId
                    select new ListKnowledgeBaseModel
                    {
                        QuestionId = kb.QuestionId,
                        ServiceTypeId = st.ServiceTypeId,
                        ServiceTypeDescription = st.Description,
                        Question = kb.Question,
                        Answer = kb.Answer,
                        InquiriesQuantity = kb.InquiriesQuantity

                    }).OrderByDescending(kb => kb.InquiriesQuantity)
                    .ToList();
            return Ok(data);
        }

        [HttpPost("crtKnowledgeBase")]
        // Parámetros que se deben enviar en el body-request: CreateKnowledgeBaseModel => ServiceTypeId, Question, Answer, Pinned y CreationUser
        public void CreateKnowledgeBase(CreateKnowledgeBaseModel model)
        {
            KnowledgeBase knowledgeBase = new KnowledgeBase
            {
                ServiceTypeId = model.ServiceTypeId,
                Question = model.Question,
                Answer = model.Answer,
                Pinned = model.Pinned,
                CreationDate = DateTime.Now,
                CreationUser = model.CreationUser
            };

            db.KnowledgeBase.Add(knowledgeBase);
            db.SaveChanges();
        }

        [HttpDelete("dltKnowledgeBase")]
        // Parámetros que se deben enviar en el body-request: DeleteKnowledgeBaseModel => QuestionId
        public void DeleteKnowledgeBase(DeleteKnowledgeBaseModel model)
        {
            db.Remove(db.KnowledgeBase.Single(kb => kb.QuestionId == model.QuestionId));
            db.SaveChanges();
        }

        [HttpPut("updKnowledgeBase")]
        // Parámetros que se deben enviar en el body-request: UpdateKnowledgeBaseModel => QuestionId, ServiceTypeId, Question, Answer, Pinned y CreationUser
        public void UpdateKnowledgeBase(UpdateKnowledgeBaseModel model)
        {
            var knowledgeBase = db.KnowledgeBase.First(kb => kb.QuestionId == model.QuestionId);

            knowledgeBase.ServiceTypeId = model.ServiceTypeId;
            knowledgeBase.Question = model.Question;
            knowledgeBase.Answer = model.Answer;
            knowledgeBase.Pinned = model.Pinned;
            knowledgeBase.CreationUser = model.CreationUser;
            knowledgeBase.CreationDate = DateTime.Now;

            db.SaveChanges();
        }

        [HttpPut("updKBPositiveRate")]
        // Parámetros que se deben enviar en el body-request: RateKnowledgeBaseModel => QuestionId
        public void UpdateKBPositiveRate(RateKnowledgeBaseModel model)
        {
            var knowledgeBase = db.KnowledgeBase.First(kb => kb.QuestionId == model.QuestionId);

            knowledgeBase.PositiveCalification += 1;

            db.SaveChanges();
        }

        [HttpPut("updKBNegativeRate")]
        // Parámetros que se deben enviar en el body-request: RateKnowledgeBaseModel => QuestionId
        public void UpdateKBNegativeRate(RateKnowledgeBaseModel model)
        {
            var knowledgeBase = db.KnowledgeBase.First(kb => kb.QuestionId == model.QuestionId);

            knowledgeBase.NegativeCalification += 1;

            db.SaveChanges();
        }

        /* Service Requests */
        [HttpPost("crtServiceRequest")]
        // Parámetros que se deben enviar en el body-request: CreateServiceRequestModel => UPCCode, FirstName, LastName, Names, Email, Career, Modality, ServiceTypeId, AttentionModeId, CampusId y CreationUser
        public IActionResult CreateServiceRequest([FromForm] CreateServiceRequestModel model)
        {
            try
            {
                byte[] file = null;
                using (var memoryStream = new MemoryStream())
                {
                    model.FileContent.CopyToAsync(memoryStream);
                    file = memoryStream.ToArray();
                }
                ServiceRequest serviceRequest = new ServiceRequest
                {
                    UPCCode = model.UPCCode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Names = model.Names,
                    Email = model.Email,
                    Career = model.Career,
                    Modality = model.Modality,
                    ServiceTypeId = model.ServiceTypeId,
                    AttentionModeId = model.AttentionModeId,
                    CampusId = model.CampusId,
                    RequestDetail = model.RequestDetail,
                    FileName = model.FileName,
                    FileContent = file,
                    ServiceStatusId = 1,
                    BUserCode = "b20200601",
                    CreationDate = DateTime.Now,
                    CreationUser = model.CreationUser
                };

                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                return Ok(
                    new
                    {
                        status = true,
                        message = "OK"
                    });
            }
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}