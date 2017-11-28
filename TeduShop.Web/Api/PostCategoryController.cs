﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;
using TeduShop.Web.Utils;
using TeduShop.Web.Infrastructure.Extensions;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("createnew")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            Log.Debug("-----------------------Demo Request------------------");
            return CreateHttpRessponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (!ModelState.IsValid)
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     PostCategory cat = new PostCategory();
                     cat.UpdatePostCategory(postCategoryVm);
                     _postCategoryService.Add(cat);
                     _postCategoryService.Save();

                     response = request.CreateResponse(HttpStatusCode.Created, cat);
                 }
                 return response;
             });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            Log.Debug("-----------------------Update Reequest------------------");
            return CreateHttpRessponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory cat = new PostCategory();
                    cat.UpdatePostCategory(postCategoryVm);
                    _postCategoryService.Update(cat);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            Log.Debug("-----------------------Delete Reequest------------------");
            return CreateHttpRessponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            Log.Debug("-----------------------GET Reequest------------------");
            return CreateHttpRessponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                   
                }
                else
                {
                    var cats = _postCategoryService.GetAll();
                    var catsVM = Mapper.Map<List<PostCategory>>(cats);
                    Log.Debug(cats.Count().ToString());
                    response = request.CreateResponse(HttpStatusCode.OK, catsVM);
                }
                return response;
            });
        }

    }
}