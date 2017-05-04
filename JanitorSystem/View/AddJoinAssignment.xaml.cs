using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JanitorSystem.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddJoinAssignment : Page
    {
        public AddJoinAssignment()
        {
            this.InitializeComponent();
        }
        public void AddJoinToFP (object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AssignmentListFrontPage), null);
        }

        public void AddJoinToAddAssign (object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddAssignment), null);
        }

        public void AddJoinToAddJoin (object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddJoinAssignment), null);
        }

        public void AddJoinToPhone (object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PhoneBook), null);
        }
    }
}
