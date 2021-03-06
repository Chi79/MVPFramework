namespace ERP.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ALARMSTATUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALARMSTATUS()
        {
            ALARMTRACKER = new HashSet<ALARMTRACKER>();
        }

        [Key]
        [Column("AlarmStatus")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlarmStatus1 { get; set; }

        [Required]
        [StringLength(40)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALARMTRACKER> ALARMTRACKER { get; set; }
    }
}
