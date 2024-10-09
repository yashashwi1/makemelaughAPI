using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Requests
{
    /// <summary>
    /// This enum is created, to give flexibility to consumer to accept the response in
    /// either plain text or json if they further want to play with the response.
    /// </summary>
    public enum OutputTypeEnum
    {
        PlainText = 0,
        Json = 1,
    }
}
