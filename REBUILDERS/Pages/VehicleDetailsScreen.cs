using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebuilders.Utils;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using NUnit.Framework;
using Rebuilder;

namespace Rebuilders.Pages
{   
    public class VehicleDetailsScreen : BasePage
    {
        public IApp app;
        public Query ItemImage { get; } = new Query(c => c.Marked("imgVeh"));
        public Query lblYearMakeModel { get; } = new Query(c => c.Marked("lblYearMakeModel"));
        public Query lblValue { get; } = new Query(c => c.Marked("lblValue"));
        public Query lblLocationName { get; } = new Query(c => c.Marked("lblLocationName"));
        public Query lblLocationAddress { get; } = new Query(c => c.Marked("lblLocationAddress"));
        public Query lblContact { get; } = new Query(c => c.Marked("lblContact"));
        public Query lblContactEmail { get; } = new Query(c => c.Marked("lblContactEmail"));
        public Query lblContactPhone { get; } = new Query(c => c.Marked("lblContactPhone"));
        public Query lblMileageValue { get; } = new Query(c => c.Marked("lblMileageValue"));
        public Query lblEmail { get; } = new Query(c => c.Marked("lblEmail"));
        public Query lblCall { get; } = new Query(c => c.Marked("lblCall"));
        public Query lblBrandingValue { get; } = new Query(c => c.Marked("lblBrandingValue"));
        public Query lblVINValue { get; } = new Query(c => c.Marked("lblVINValue"));
        public Query lblFileNumber { get; } = new Query(c => c.Marked("lblFileNumber"));
        public Query lblFileNumberValue { get; } = new Query(c => c.Marked("lblFileNumberValue"));
        public Query lblTypeValue { get; } = new Query(c => c.Marked("lblTypeValue"));
        public Query slMoreInfo { get; } = new Query(c => c.Marked("slMoreInfo"));
        public Query lblMoreLessInfo { get; } = new Query(c => c.Marked("lblMoreLessInfo"));
        public Query imgShowMore { get; } = new Query(c => c.Marked("imgShowMore"));
        public Query lblDescription { get; } = new Query(c => c.Marked("lblDescription"));
        public Query lblNoDescription { get; } = new Query(c => c.Marked("lblNoDescription"));
        public Query lblDisclaimer { get; } = new Query(c => c.Marked("lblDisclaimer"));
        public string title;

        string yearMakeModel;
        string value;
        string locationName;
        string locationAddress;
        string contactName;
        string contactEmail;
        string contactPhone;
        string mileage;
        string branding;
        string VIN;
        string fileNumber;
        string type;
        string description;
        public PickerDialog picker;

        public VehicleDetailsScreen(IApp app) : base(app)
        {
            picker = new PickerDialog(Settings.AppContext);
        }

        public void InitialLoadVehicleDetails()
        {
            Settings.AppContext.WaitForElement(ItemImage);
            Settings.AppContext.Screenshot("Initial Load of Vehicle Details Screen");
            OpenImage();
            Settings.AppContext.Back();

            FirstScreen();

            ScrollTo(lblBrandingValue);
            branding = Settings.AppContext.WaitForElement(lblBrandingValue)[0].Text;
            Settings.AppContext.Screenshot("Branding: " + branding);

            ScrollTo(lblVINValue);
            VIN = Settings.AppContext.WaitForElement(lblVINValue)[0].Text;
            Settings.AppContext.Screenshot("VIN number: " + VIN);

            ScrollTo(lblFileNumber);
            fileNumber = Settings.AppContext.WaitForElement(lblFileNumberValue)[0].Text;
            Settings.AppContext.Screenshot("File Number: " + fileNumber);

            ScrollTo(imgShowMore);
            Settings.AppContext.Tap(imgShowMore);
            Settings.AppContext.Screenshot("Tapped the Show More button");

            ScrollTo(lblTypeValue);
            type = Settings.AppContext.WaitForElement(lblTypeValue)[0].Text;
            Settings.AppContext.Screenshot("Vehicle Type: " + type);

            ScrollTo(lblDescription);
            description = Settings.AppContext.WaitForElement(lblDescription)[0].Text;
            Settings.AppContext.Screenshot("Description: " + description);
        }

        public void OpenImage()
        {
            Settings.AppContext.Tap(ItemImage);
            Settings.AppContext.Screenshot("Image displayed");
            Settings.AppContext.PinchToZoomIn("zmImage");
            Settings.AppContext.Screenshot("Image zoomed in");
            Settings.AppContext.PinchToZoomOut("zmImage");
            Settings.AppContext.Screenshot("Image zoomed out");
        }

        public override string ToString()
        {

            return "Year/Make/Model: " + yearMakeModel + "\n"
                + "Valued at: " + value + "\n"
                + "Mileage: " + mileage + "\n"
                + "Located at " + locationName + "\n"
                + locationAddress + "\n"
                + "Contact Information: " + contactName + "\n"
                + contactEmail + "\n"
                + contactPhone + "\n"
                + "Additional Info: " + "\n" 
                + branding + "\n"
                + "VIN#: " + VIN + "\n"
                + "File#: " + fileNumber + "\n"
                + "Vehicle Type: " + type + "\n";
        }

        public void CallSales()
        {
            FirstScreen();
            Settings.AppContext.Tap("lblCall");
            Settings.AppContext.Screenshot("Verify that the number entered into dialer is: "  + contactPhone);
        }

        public void EmailSales()
        {
            FirstScreen();
            if(Settings.AppContext.Query("Send Email").Count()<1)
            {
                Settings.AppContext.ScrollTo("lblEMail");
            }

            Settings.AppContext.Tap("lblEmail");
            Settings.AppContext.Screenshot("Verify that the email address entred into the To line is: " + contactEmail);
        }

        public void FirstScreen()
        {
            Settings.AppContext.Screenshot("Initial Load of Vehicle Details Screen");

            yearMakeModel = Settings.AppContext.WaitForElement(lblYearMakeModel)[0].Text;
            Settings.AppContext.Screenshot("YearMakeModel: " + yearMakeModel);

            ScrollTo(lblValue);
            value = Settings.AppContext.WaitForElement(lblValue)[0].Text;
            Settings.AppContext.Screenshot("Value: " + value);

            ScrollTo(lblLocationName);
            locationName = Settings.AppContext.WaitForElement(lblLocationName)[0].Text;
            Settings.AppContext.Screenshot("Location Name: " + locationName);

            ScrollTo(lblLocationAddress);
            locationAddress = Settings.AppContext.WaitForElement(lblLocationAddress)[0].Text;
            Settings.AppContext.Screenshot("Location Address: " + locationAddress);

            ScrollTo(lblContact);
            contactName = Settings.AppContext.WaitForElement(lblContact)[0].Text;
            Settings.AppContext.Screenshot("Contact Name: " + contactName);

            ScrollTo(lblContactEmail);
            contactEmail = Settings.AppContext.WaitForElement(lblContactEmail)[0].Text;
            Settings.AppContext.Screenshot("Contact Email: " + contactEmail);

            ScrollTo(lblContactPhone);
            contactPhone = Settings.AppContext.WaitForElement(lblContactPhone)[0].Text;
            Settings.AppContext.Screenshot("Contact Phone: " + contactPhone);

            ScrollTo(lblMileageValue);
            mileage = Settings.AppContext.WaitForElement(lblMileageValue)[0].Text;
            Settings.AppContext.Screenshot("Mileage: " + mileage);
        }

        public void OpenLocation()
        {
            FirstScreen();
            if (Settings.AppContext.Query("lblLocationName").Count() < 1)
            {
                Settings.AppContext.ScrollTo("lblLocationName");
            }
            Settings.AppContext.Tap("lblLocationName");
            Settings.AppContext.Screenshot("Verify that the address opened in the map app is: " + locationAddress);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    
}
