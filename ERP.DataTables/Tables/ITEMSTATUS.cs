namespace ERP.DataTables.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ITEMSTATUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEMSTATUS()
        {
            ITEMTRACKER = new HashSet<ITEMTRACKER>();
        }

        [Key]
        [Column("ItemStatus")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemStatus1 { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMTRACKER> ITEMTRACKER { get; set; }
    }
}
