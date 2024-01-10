﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface IMessage
{
    IEnumerable<Models.Message> GetUserMessage(int id);

    bool Add(Models.Message message);

    bool Update(Models.Message message);

    List<Models.Message> GetAll();
}
