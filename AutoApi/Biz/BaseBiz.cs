﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi.Biz
{
    public class BaseBiz
    {
        protected ILog logger = LogManager.GetLogger(typeof(BaseBiz));
    }
}
