using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Entities
{
    public class UserState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  bool Room_1 { get; set; }=false;
        public  bool Room_2 { get; set; }=false;
        public  bool Room_3 { get; set; }=false;
        public  bool Room_4 { get; set; }=false;
        public  bool Room_Final { get; set; }=false;
        public  bool FinalState { get; set; }=false;
        public  bool Is_visible { get; set; }=true;

        public int IdUser { get; set; }

        [ForeignKey("IdUser")]
        public virtual UserInfo UserInfo { get; set; }
    }
}
