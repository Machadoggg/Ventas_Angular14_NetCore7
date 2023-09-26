namespace Ventas.BusinessLogicLayer.Menus
{
    public class DashBoardManager : IDashBoardManager
    {
        private readonly IDashBoardRepository _dashBoardRepositorio;

        public DashBoardManager(IDashBoardRepository dashBoardRepositorio)
        {
            _dashBoardRepositorio = dashBoardRepositorio;
        }

        public async Task<DashBoard> Resumen()
        {
            var listaVentaSemana = await _dashBoardRepositorio.ResumenAsync().ConfigureAwait(false);
            return listaVentaSemana;
        }
    }
}
