﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Bases
{
    public class ResponseHandler
    {

        public ResponseHandler()
        {
           
        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>() {
                //StatusCode = System.Net.HttpStatusCode.OK,
                //Succeeded = true,
                //Message = "Deleted Successfully"
            };
        }
        public Response<T> Success<T>(T entity)
        {
            return new Response<T>() {
                Data = entity,
                //StatusCode = System.Net.HttpStatusCode.OK,
                //Succeeded = true,
                //Message = "Added Successfully",
                //Meta = Meta
            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>() {
                //StatusCode = System.Net.HttpStatusCode.Unauthorized,
                //Succeeded = true,
                //Message = "UnAuthorized"
            };
        }
        public Response<T> BadRequest<T>(string Message )
        {
            return new Response<T>() {
                //StatusCode = System.Net.HttpStatusCode.BadRequest,
                //Succeeded = false,
                //message = Message == null ? "Bad Request" : Message
            };
        }

        public Response<T> NotFound<T>(string Message =null)
        {
            return new Response<T>() {
                //StatusCode = System.Net.HttpStatusCode.NotFound,
                //Succeeded = false,
               // Message = Message == null ? "Not Found" : Message
            };
        }
        
        public Response<T> Created<T>(T entity)
        {
            return new Response<T>() {
                Data = entity,
                //StatusCode = System.Net.HttpStatusCode.Created,
                //Succeeded = true,
                //Message = _localizer[SharedResourcesKeys.Created],
                //Meta = Meta
            };
        }

    }
}
