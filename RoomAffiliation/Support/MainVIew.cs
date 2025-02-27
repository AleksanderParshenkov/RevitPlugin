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
                        
        }
    }
}
