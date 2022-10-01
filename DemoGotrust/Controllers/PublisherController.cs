using BAL.Services;
using DAL.Models;
using DAL.Utilities;
using DemoGotrust.Models.Request;
using DemoGotrust.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoGotrust.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/<PublisherController>
        [HttpGet]
        public async Task<ActionResult<PaginationResponse<BasicPublisherResponse>>> Get([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 0)
        {
            try
            {
                PaginatedResult<Publisher> publishers = await _publisherService.GetAllPublishers(pageSize, pageNumber);
                return publishers != null ? Ok(new PaginationResponse<BasicPublisherResponse>{
                        limit = publishers.limit,
                        page = publishers.page,
                        total = publishers.total,
                        objects = publishers.objects.Select(publisher => new BasicPublisherResponse(publisher)).ToList()
                }) : Ok(new List<BasicPublisherResponse>());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicPublisherResponse>> Get(string id)
        {
            try { 
                Publisher publisher = await _publisherService.GetPublisherbyId(id);
                return publisher != null ? Ok(new BasicPublisherResponse(publisher)) : null;
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<PublisherController>
        [HttpPost]
        public async Task<ActionResult<Publisher>> Post([FromBody] CreatePublisherRequest publisher)
        {
            try
            {
                Publisher createdPublisher = await _publisherService.CreatePublisher(new Publisher { PublisherId = publisher.PublisherId, Description = publisher.Description, PublisherName = publisher.PublisherName });
                if (createdPublisher == null) return UnprocessableEntity();
                return Ok(new BasicPublisherResponse(createdPublisher));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                if(ex.InnerException.Message.Contains("duplicate key"))
                {
                    return BadRequest("Duplicate key!");
                }

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<PublisherController>/5
        [HttpPut]
        public async Task<ActionResult<Publisher>> Put([FromBody] UpdatePublisherRequest publisher)
        {
            try
            {
                Publisher updatedPublisher = await _publisherService.UpdatePublisher(new Publisher { PublisherId = publisher.PublisherId, Description = publisher.Description, PublisherName = publisher.PublisherName });
                if (updatedPublisher == null) return UnprocessableEntity();
                return Ok(new BasicPublisherResponse(updatedPublisher));
            }catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublisherResponse>> Delete(string id)
        {
            try
            {
                var publisher = await _publisherService.DeletePublisher(id);
                return new PublisherResponse
                {
                    PublisherId = publisher.PublisherId,
                    Description = publisher.Description,
                    PublisherName = publisher.PublisherName,
                    Books = publisher.Books.Select(book => new BasicBookResponse(book))
                };
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            } catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
