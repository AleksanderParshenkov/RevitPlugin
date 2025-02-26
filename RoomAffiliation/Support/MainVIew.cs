using RoomAffiliation.Views;

namespace RoomAffiliation.Controllers
{
    public static class MainVIew
    {
        public static MainWindow MainWindow {get;set;}       


        public static void WriteStartValues()
        {      
            // Постоянные значения первых двух параметров помещений. Запрещено изменять пользователю.
            MainWindow.tb_ParameterRoom_1.Text = "Имя";
            MainWindow.tb_ParameterRoom_1.IsEnabled = false;

            MainWindow.tb_ParameterRoom_2.Text = "Номер";
            MainWindow.tb_ParameterRoom_2.IsEnabled = false;

            // Временно для отладки.
            MainWindow.tb_ParameterElement_1.Text = "ROM_Имя помещения в офисе";

            MainWindow.tb_ParameterElement_2.Text = "ROM_Номер";
        }
    }
}
