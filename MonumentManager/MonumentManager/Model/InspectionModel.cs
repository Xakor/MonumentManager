using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentManager.Model
{
    class InspectionModel
    {
        //Properties
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int sculptureId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
    }
}
