﻿using BL.AtomicDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WasteManagerWebApi.Controllers
{
    public class BinController : BaseController
    {

        [HttpGet]
        public List<BinData> GetAllBins()
        {
            throw new NotImplementedException();
        }

    }
}
