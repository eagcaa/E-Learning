﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService : IGenericService<Content>
    {
        List<Content> GetContentsByType(ContentType contentType);
    }
}
