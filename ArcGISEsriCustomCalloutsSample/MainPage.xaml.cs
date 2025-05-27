namespace ArcGISEsriCustomCalloutsSample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        var viewModel = (MapViewModel)Resources["MapViewModel"];
        viewModel.MapView = MainMapView;
    }
}