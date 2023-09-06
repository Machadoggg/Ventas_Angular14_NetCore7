namespace Ventas.Model
{
    public partial class MenuRol
    {
        public int Id { get; set; }

        public int IdMenu { get; set; }

        public int IdRol { get; set; }

        public virtual Menu IdMenuNavigation { get; set; } = default!;

        public virtual Rol IdRolNavigation { get; set; } = default!;
    }
}
