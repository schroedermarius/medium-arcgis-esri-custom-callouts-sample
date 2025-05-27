using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGISEsriCustomCalloutsSample;

public partial class CustomCallout : Grid
{
    public CustomCallout(string label, string value)
    {
        InitializeComponent();
        
        Label.Text = label;
        Description.Text = value;
    }
}