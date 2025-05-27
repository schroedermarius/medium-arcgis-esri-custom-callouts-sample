using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Geometry;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.UI;
using Map = Esri.ArcGISRuntime.Mapping.Map;

namespace ArcGISEsriCustomCalloutsSample;

internal class MapViewModel : INotifyPropertyChanged
{
    private Map _map;
    private MapView _mapView;

    public Map Map
    {
        get => _map;
        set
        {
            _map = value;
            OnPropertyChanged();
        }
    }

    public MapView MapView
    {
        get => _mapView;
        set
        {
            _mapView = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCustomCalloutCommand { get; }
    public ICommand AddDefaultCalloutCommand { get; }

    public MapViewModel()
    {
        SetupMap();
        
        AddCustomCalloutCommand = new Command(() =>
        {
            // Create a custom callout with a label and value.
            CustomCallout customCallout = new CustomCallout(
                "Medialesson GmbH",
                "https://www.medialesson.de\nHabermehlstraße 15\nD-75172 Pforzheim\nGermany\nMedialesson develops innovative software solutions, specializing in cloud computing, AI, mobile apps, and custom software."
            );

            // Set the callout's position to a specific point on the map.
            var calloutPoint = new MapPoint(8.687525717617417, 48.89138246211073, SpatialReferences.Wgs84);

            // Show the custom callout on the map.
            MapView.ShowCalloutAt(calloutPoint, customCallout);
        });
        
        AddDefaultCalloutCommand = new Command(() =>
        {
            // Set the callout's position to a specific point on the map.
            var calloutPoint = new MapPoint(8.687525717617417, 48.89138246211073, SpatialReferences.Wgs84);

            // Show the default callout on the map.
            MapView.ShowCalloutAt(calloutPoint, new CalloutDefinition("Medialesson GmbH",
                "https://www.medialesson.de\nHabermehlstraße 15\nD-75172 Pforzheim\nGermany\nMedialesson develops innovative software solutions, specializing in cloud computing, AI, mobile apps, and custom software."));
        });
    }
    
    private void SetupMap()
    {
        // Create a new map with a 'topographic vector' basemap.
        Map = new Map(BasemapStyle.ArcGISTopographic);

        var mapCenterPoint = new MapPoint(8.687525717617417, 48.89138246211073, SpatialReferences.Wgs84);
        Map.InitialViewpoint = new Viewpoint(mapCenterPoint, 100000);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}