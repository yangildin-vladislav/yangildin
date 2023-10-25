namespace YangildinAutoService
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows;

    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.ClientService = new HashSet<ClientService>();
            this.ServicePhoto = new HashSet<ServicePhoto>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string MainImagePath { get; set; }
        public int Duration { get; set; }
        public decimal Cost { get; set; }
        public Nullable<double> Discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientService> ClientService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePhoto> ServicePhoto { get; set; }


        public string OldCost
        {
            get
            {
                if (Discount > 0)
                {
                    return Cost.ToString("F2");
                }
                else
                {
                    return "";
                }
            }
        }

        public SolidColorBrush FonStyle
        {
            get
            {
                if (Discount > 0)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("LightGreen");
                }
                else
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }
            }
        }

        public decimal FinalCost
        {
            get
            {
                if (Discount.HasValue && Discount.Value > 0)
                {
                    return Math.Round(Cost * (decimal)((100 - Discount.Value) / 100), 2);
                }
                else
                {
                    return Cost;
                }
            }
        }

        public TextDecorationCollection CostStrikethrough
        {
            get
            {
                if (Discount.HasValue && Discount.Value > 0)
                {
                    return TextDecorations.Strikethrough;
                }
                else
                {
                    return new TextDecorationCollection();
                }
            }
        }
    }
}
