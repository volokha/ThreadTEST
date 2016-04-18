using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MyQ : Queue<Process>
{
    public static MyQ instance;

    private MyQ() { }

    public static MyQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MyQ();
            }
            return instance;
        }
    }
}