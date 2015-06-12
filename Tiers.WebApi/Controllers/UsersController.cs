using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tiers.Core;
using Tiers.Service;

namespace Tiers.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/user
        public IEnumerable<UserDTO> Get()
        {
            return new UserService().GetAll();
        }

        // GET api/user/id
        public UserDTO Get(int id)
        {
            return new UserService().Get(id);
        }

        // POST api/user
        public HttpResponseMessage Post([FromBody]UserDTO user)
        {
            if (ModelState.IsValid)
            {
                user = new UserService().Create(user);
                if (Request != null) // Skip response if Request is null (unit testing)
                {
                    var response = 
                        Request.CreateResponse<UserDTO>(HttpStatusCode.Created, user);

                    string uri = Url.Link("DefaultApi", new { id = user.ID });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
            }
            else
            {
                return 
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/values/user
        public UserDTO Put(int id, [FromBody]string value)
        {
            return new UserService().Update(new UserDTO() { ID = id, Name = value });
        }

        // DELETE api/values/id
        public int Delete(int id)
        {
            return new UserService().Delete(id);
        }
    }
}