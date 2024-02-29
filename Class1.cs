using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace курсовая
{
    public partial class Предметы
    {
        public override string ToString()
        {
            return НазваниеПредмета;
        }
    }

    public partial class Оценки
    {
        public override string ToString()
        {
            return Оценка;
        }
    }

    public partial class Студенты
    {
        public override string ToString()
        {
            return ФИО;
        }
    }
    public partial class Группа
    {
        public override string ToString()
        {
            return Название;
        }
    }

}
