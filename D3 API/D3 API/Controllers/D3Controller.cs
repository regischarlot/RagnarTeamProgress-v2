using System;
using System.Web.Http;
using D3_API.Models;

namespace D3_API.Controllers
{
    [RoutePrefix("api/v1/d3")]
    public class D3Controller : ApiController
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns> 
        [Route("foundation")] // GET /api/v1/d3/foundation
        [HttpGet]
        public IHttpActionResult GetFoundationAsync()
        {
            TcResponse result = new TcResponse();
            result.TelemetryStart("foundation", Request);
            try
            {
                TcContext ctx = new TcContext(new TcEnvironment());
                result.Success = ctx.Load();
                if (result.Success)
                    result.Data = ctx;
            }
            catch (Exception e)
            {
                result.Error = e.Message;
                result.TelemetryException(e);
            }
            finally
            {
                result.TelemetryStop();
            }
            // Done.
            return Json(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns> 
        [Route("runner")] // POST /api/v1/d3/runner
        [HttpPost]
        public IHttpActionResult PostRunnerAsync(TcRunner value)
        {
            if (!ModelState.IsValid || value == null)
                return BadRequest("Invalid data.");
            TcResponse result = new TcResponse();
            result.TelemetryStart("runner", Request);
            try
            {
                value.Environment = new TcEnvironment();
                result.Success = value.Update();
                if (result.Success)
                    result.Data = value;
            }
            catch (Exception e)
            {
                result.Error = e.Message;
                result.Data = false;
                result.TelemetryException(e);
            }
            finally
            {
                result.TelemetryStop();
            }
            // Done.
            return Json(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns> 
        [Route("runner")] // PUT /api/v1/d3/runner
        [HttpPut]
        public IHttpActionResult PutRunnerAsync(TcRunner value)
        {
            if (value == null)
                return BadRequest("Invalid data.");
            TcResponse result = new TcResponse();
            result.TelemetryStart("runner", Request);
            try
            {
                value.Environment = new TcEnvironment();
                result.Success = value.Create();
                if (result.Success)
                    result.Data = value;
            }
            catch (Exception e)
            {
                result.Error = e.Message;
                result.Data = false;
                result.TelemetryException(e);
            }
            finally
            {
                result.TelemetryStop();
            }
            // Done.
            return Json(result);
        }
    }
}