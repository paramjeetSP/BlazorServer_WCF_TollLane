using BlazorServer_WCF.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Toolbelt.Blazor.HotKeys;

namespace BlazorServer_WCF.Web.Pages
{
    /// <summary>
    /// Image Review
    /// </summary>
    public partial class ImageReview
    {
        /// <summary>
        /// Image Review Constroctor
        /// </summary>
        public ImageReview()
        {
            _Utils = new ImageReviewUtils();
            TIDs = new List<long>();
            Jurisdictions = new List<JurisdictionModel>();
            FormData = new ImageReviewFormData();
        }

        #region Image Utils Model

        /// <summary>
        /// Image Review Utils
        /// </summary>
        public class ImageReviewUtils
        {
            public int brightness { get; set; } = 100;

            public int contrast { get; set; } = 100;

            public int grayscale { get; set; } = 0;

            public int invert { get; set; } = 0;

            public string filterSet = $"filter:brightness(100%) contrast(100%) grayscale(0%) invert(0%);";

            public bool isNextDisabled { get; set; } = true;

            public bool isPrevDisabled { get; set; } = true;

            public string css { get; set; }

            public string PrimarySrc { get; set; } = @"/images/image-preview.jpg";

            public string ROI { get; set; } = @"/images/image-preview.jpg";

            public string LOI { get; set; } = @"/images/image-preview.jpg";

            public string DialogCss { get; set; }

            public long Seleted { get; set; } = 1;

            public bool isMagnifier { get; set; } = false;

            public string MagnifierID { get; set; } = "MagnifierImage";

            public string ZoomScrollID { get; set; } = "ZoomScrollImage";
        }


        /// <summary>
        /// Image Review Data Model
        /// </summary>
        public class ImageReviewFormData
        {
            public int JurisdictionId { get; set; }

            public string Registration { get; set; }

            public string Jurisdiction { get; set; }

            public string CodeOff { get; set; }

            public DateTime? ExpDate { get; set; } = null;

            public bool IsJError { get; set; } = true;

            public bool IsJSuccess { get; set; } = false;
        }

        #endregion


        #region Variable Declarations

        public ServiceReference1.Transaction objTransaction = new();

        ServiceReference1.User logedinuser = new();

        private HttpClient objHttp = new HttpClient();

        HotKeysContext HotKeysContext;

        public ImageReviewUtils _Utils { get; set; }

        public string FolderID { get; set; } = "N/A";

        public string ImageGroupID { get; set; } = "N/A";

        public string TransationID { get; set; } = "N/A";

        public string Age { get; set; } = "N/A";

        public int AssignmentsCount { get; set; }

        List<long> TIDs;

        public string ImageReviewer { get; set; } = "N/A";

        private ElementReference BrightnessRef;

        private ElementReference ContrastRef;

        private ElementReference GrayscaleRef;

        private ElementReference InvertRef;

        #endregion


        #region Review Form Variable Declarations

        List<JurisdictionModel> Jurisdictions;

        ImageReviewFormData FormData;

        //bool isNext = false;

        //bool needStart = false;

        bool isRegistrationOptional = false;

        bool isCodeOffOptional = false;

        string codeOffPlaceholder = "Code Off";

        string registrationPlaceholder = "Registration";

        string successPlaceholder = "Code is Valid";

        string successBSClass = "text-success";

        #endregion

        #region Razor Functions

        /// <summary>
        /// On Initialized
        /// </summary>
        protected override void OnInitialized()
        {
            this.HotKeysContext = this.HotKeys.CreateContext()
          .Add(ModKeys.Ctrl, Keys.B, Brigntness, "Arrow keys to change Brightness")
          .Add(ModKeys.Ctrl, Keys.K, Contrast, "Arrow keys to change Contrast")
          .Add(ModKeys.Ctrl, Keys.G, Grayscale, "Arrow keys to change Grayscale")
          .Add(ModKeys.Ctrl, Keys.I, Invert, "Arrow keys to change Invert");

            Jurisdictions = UtilsService.GetJurisdiction();
        }

        /// <summary>
        /// Dispose Hot Keys event
        /// </summary>
        public void Dispose()
        {
            this.HotKeysContext.Dispose();
        }


        /// <summary>
        /// Begin Transaction
        /// </summary>
        /// <returns></returns>
        public async Task BeginTransaction()
        {
            var result = await (DialogService.Confirm("Are you sure you want to Start the Transaction?", "Start Transaction",
          new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" }));

            if (Convert.ToBoolean(result))
            {
                try
                {
                    await Task.Delay(500);
                    BusyDialog();

                    var myInts = new List<int>() { 1 };
                    if (CoreService.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
                    {
                        // call service - everything's fine
                        var userName = @"GLOBALAGILITY\mandeep.singh";
                        logedinuser = CoreService.Login(userName, "");
                        AssignmentsCount = logedinuser.Assignments.Length;
                        if (AssignmentsCount > 0)
                        {
                            TIDs = logedinuser.Assignments.Select(a => a.ID).ToList();
                            if (TIDs.Count > 0)
                            {
                                await GetReview(logedinuser);
                            }
                        }
                        else
                        {
                            ShowNotification(new NotificationMessage
                            {
                                Severity = NotificationSeverity.Error,
                                Summary = "Error",
                                Detail = "There is no Transaction available for this time. Please try again later.",
                                Duration = 8000
                            });
                        }

                    }
                    else
                    {
                        // channel faulted - re-create your client and then try again
                    }

                    DialogService.Close();
                }
                catch (Exception ex)
                {
                    DialogService.Close();
                    ShowNotification(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Summary = "Error",
                        Detail = ex.Message,
                        Duration = 8000
                    });
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        public async Task<bool> GetReview(ServiceReference1.User logedinuser)
        {
            bool bolStarting = CoreService.StartAssignment(1);
            await Task.Delay(10000);
            objTransaction = CoreService.GetReview();
            if (objTransaction == null)
            {
                objTransaction = CoreService.GetReview();
            }
            //var GetTran = CoreService.GetTransaction(TIDs[0]);

            if (objTransaction == null)
            {
                ShowNotification(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Detail = "There is no Transaction available for this time. Please try again later.",
                    Summary = "Error",
                    Duration = 5000
                });
                _Utils.PrimarySrc = @"/images/image-preview.jpg";
                _Utils.isNextDisabled = true;
                _Utils.isPrevDisabled = true;
                return false;
            }
            else if (objTransaction.Images.Count() > 0 && logedinuser != null)
            {
                InitializePrimaryIMG(objTransaction.Images.ToList());
                InitializeROIIMG(objTransaction.Images.ToList());
                SetSubImageReviewValues(logedinuser, objTransaction);
                _Utils.isNextDisabled = false;
                _Utils.isPrevDisabled = false;

                return true;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// End Transaction
        /// </summary>
        /// <returns></returns>
        public async Task EndTransaction()
        {
            try
            {
                var result = await DialogService.Confirm("Are you sure you want to End the Transaction?",
                    "End Transaction", new ConfirmOptions()
                    {
                        OkButtonText = "Yes",
                        CancelButtonText = "No"
                    });
                if (Convert.ToBoolean(result))
                {
                    var aa = await CoreService.StopAssignmentAsync();
                    await Task.Delay(5000);
                    NavigationManager.NavigateTo("/ImageReview", true);
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Detail = ex.Message,
                    Summary = "Error",
                    Duration = 8000
                });
                Console.Write(ex.ToString());
            }
        }


        /// <summary>
        /// Initialize Primary IMG
        /// </summary>
        /// <param name="objImages"></param>
        protected void InitializePrimaryIMG(List<ServiceReference1.TollImage> objImages)
        {
            if (objImages.Count > 0)
            {
                foreach (var item in objImages)
                {
                    if (item.Perspective == 0)
                    {
                        _Utils.PrimarySrc = GetImagePath(item);
                        break;
                    }
                    else if (item.Perspective == 1)
                    {
                        _Utils.PrimarySrc = GetImagePath(item);
                        break;
                    }
                }
            }

        }


        /// <summary>
        /// Initialize ROI IMG
        /// </summary>
        /// <param name="objImages"></param>
        protected void InitializeROIIMG(List<ServiceReference1.TollImage> objImages)
        {
            if (objImages.Count > 0)
            {
                foreach (var item in objImages)
                {
                    if (item.Perspective == 2)
                    {
                        _Utils.LOI = GetImagePath(item);
                        break;
                    }
                    else if (item.Perspective == 3)
                    {
                        _Utils.LOI = GetImagePath(item);
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Get Image Correct Image path from FTP URL//
        /// </summary>
        /// <param name="objImage"></param>
        /// <returns></returns>
        string GetImagePath(ServiceReference1.TollImage objImage)
        {
            string strPath = objImage.Path.Replace('\\', '/');
            return GetInlineImageSrcAsync(strPath);
        }


        /// <summary>
        /// Get Image From FTP Path//
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        public string GetInlineImageSrcAsync(string strURL)
        {
            try
            {
                var bytBytes = File.ReadAllBytes(strURL);
                var base64 = Convert.ToBase64String(bytBytes);
                var mimeType = "image/jpg";
                var image64Str = $"data:{mimeType};base64,{base64}";
                return image64Str;
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Detail = ex.Message,
                    Summary = "Error",
                    Duration = 5000
                });
                Console.Write(ex.ToString());
                throw;
            }
        }


        /// <summary>
        /// Select Image
        /// </summary>
        /// <param name="src"></param>
        /// <param name="id"></param>
        public void SelectImage(string src, long id)
        {
            _Utils.PrimarySrc = src; _Utils.Seleted = id;
            SetButtonVisiblityStatus(id);
        }


        /// <summary>
        /// Show Notification
        /// </summary>
        /// <param name="message"></param>
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }


        /// <summary>
        /// Change Filter
        /// </summary>
        /// <param name="value"></param>
        /// <param name="filter"></param>
        public void ChangeFilter(string value, int filter)
        {
            switch (filter)
            {
                case (int)Filter.brightness:
                    _Utils.css = $"filter: brightness( {value}%) contrast( {_Utils.contrast}%) grayscale({_Utils.grayscale}%) invert({_Utils.invert}%);";
                    break;
                case (int)Filter.contrast:
                    _Utils.css = $"filter:brightness({_Utils.brightness}%) contrast({value}%) grayscale({_Utils.grayscale}%) invert({_Utils.invert}%);";
                    break;
                case (int)Filter.grayscale:
                    _Utils.css = $"filter:brightness({_Utils.brightness}%) contrast({_Utils.contrast}%) grayscale({value}%) invert({_Utils.invert}%);";
                    break;
                case (int)Filter.invert:
                    _Utils.css = $"filter:brightness({_Utils.brightness}%) contrast({_Utils.contrast}%) grayscale({_Utils.grayscale}%) invert({value}%);";
                    break;
                default:
                    _Utils.css = _Utils.filterSet;
                    break;
            }
        }

        /// <summary>
        /// Reset
        /// </summary>
        public void Reset()
        {
            _Utils.brightness = 100; _Utils.contrast = 100; _Utils.grayscale = 0; _Utils.invert = 0; _Utils.css = _Utils.filterSet; ChangeFilter(string.Empty, -1);
        }


        /// <summary>
        /// On Magnifier Switch Change
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool OnMagnifierSwitchChange(bool value)
        {
            return value ? _Utils.isMagnifier = true : _Utils.isMagnifier = false;
        }


        /// <summary>
        /// Set Sub Image Review Values
        /// </summary>
        /// <param name="user"></param>
        /// <param name="transaction"></param>
        void SetSubImageReviewValues(ServiceReference1.User user, ServiceReference1.Transaction transaction)
        {
            FolderID = user.Assignments.FirstOrDefault().ID.ToString();
            ImageGroupID = user.Assignments.FirstOrDefault().GroupID.ToString();
            ImageReviewer = user.FirstName + " " + user.LastName;
            TransationID = transaction.ID.ToString();
            Age = $"{Random.Shared.Next(25, 40)}-{Random.Shared.Next(40, 80)}";
        }


        /// <summary>
        /// Set Button Visiblity Status
        /// </summary>
        /// <param name="id"></param>
        public void SetButtonVisiblityStatus(long id)
        {
            if (id == 1)
            {
                _Utils.isPrevDisabled = true; _Utils.isNextDisabled = false;
            }
            //else if (id == Images.Count)
            //{
            //    _Utils.isPrevDisabled = false; _Utils.isNextDisabled = true;
            //}
            else
            {
                _Utils.isPrevDisabled = false; _Utils.isNextDisabled = false;
            }
        }


        /// <summary>
        /// Increase Brightness
        /// </summary>
        /// <returns></returns>
        public async Task Brigntness() => await BrightnessRef.FocusAsync();


        /// <summary>
        /// Increase Contrast
        /// </summary>
        /// <returns></returns>
        public async Task Contrast() => await ContrastRef.FocusAsync();


        /// <summary>
        /// Increase Grayscale
        /// </summary>
        /// <returns></returns>
        public async Task Grayscale() => await GrayscaleRef.FocusAsync();


        /// <summary>
        /// Increase Invert
        /// </summary>
        /// <returns></returns>
        public async Task Invert() => await InvertRef.FocusAsync();


        /// <summary>
        /// Show Hotkeys Tooltip
        /// </summary>
        /// <param name="elementReference"></param>
        /// <param name="filter"></param>
        /// <param name="options"></param>
        void ShowImageTooltip(ElementReference elementReference, int filter, TooltipOptions options = null)
        {
            switch (filter)
            {
                case (int)Filter.brightness:
                    TooltipService.Open(elementReference, "Press Ctr + B for Brightness then Arrow keys for <br> Increase / Decrease.", options);
                    break;
                case (int)Filter.contrast:
                    TooltipService.Open(elementReference, "Press Ctr + K for Contrast then Arrow keys for <br> Increase / Decrease.", options);
                    break;
                case (int)Filter.grayscale:
                    TooltipService.Open(elementReference, "Press Ctr + G for Grayscale then Arrow keys for <br> Increase / Decrease.", options);
                    break;
                case (int)Filter.invert:
                    TooltipService.Open(elementReference, "Press Ctr + I for Invert then Arrow keys for <br> Increase / Decrease.", options);
                    break;
                default:
                    TooltipService.Close();
                    break;
            }
        }

        #endregion


        #region Review Form Razor Functions
        /// <summary>
        /// Next Function
        /// </summary>
        public void Next(ImageReviewFormData data)
        {
            DialogService.Confirm("Next button clicked!", "Alert", new ConfirmOptions { OkButtonText = "OK" });
        }


        /// <summary>
        /// Submit Form
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task Submit(ImageReviewFormData args)
        {
            BusyDialog();
            ServiceReference1.ReturnResult returnResult = new ServiceReference1.ReturnResult()
            {
                ID = objTransaction.ID,
                JurisdictionID = args.JurisdictionId,
                ReviewCodeID = objTransaction.ReviewCodeID,
                TaskID = objTransaction.TaskID
            };

            returnResult.Plate = string.IsNullOrEmpty(args.Registration) ? args.CodeOff : args.Registration;


            if (await CoreService.SetResultAsync(returnResult))
            {
                FormData = new ImageReviewFormData();

                if (await GetReview(logedinuser))
                {
                    ShowNotification(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Success,
                        Summary = "Data updated successfully",
                        Duration = 5000
                    });
                }
            }

            DialogService.Close();
        }


        /// <summary>
        /// Check Jurisdiction
        /// </summary>
        /// <param name="jurisdiction"></param>
        public void CheckJurisdiction(string jurisdiction)
        {
            if (!string.IsNullOrEmpty(jurisdiction))
            {
                var res = Jurisdictions.FirstOrDefault(x => x.JCode.ToLower().Trim().Equals(jurisdiction.ToLower()));

                if (res != null)
                {
                    FormData.IsJSuccess = true; successPlaceholder = "Code is Valid"; successBSClass = "text-success";
                    FormData.IsJError = false;
                    FormData.JurisdictionId = res.JurisdictionId;
                }
                else
                {
                    FormData.IsJSuccess = true; successPlaceholder = "Entered code is invalid"; successBSClass = "text-danger";
                    FormData.IsJError = true;
                }
            }
        }


        /// <summary>
        /// Previous Function
        /// </summary>
        public void Previous(ImageReviewFormData data)
        {
            DialogService.Confirm("Back button clicked!", "Alert", new ConfirmOptions { OkButtonText = "OK" });
        }


        /// <summary>
        /// Review Form Validation
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="codeOff"></param>
        public void ReviewFormValidation(string registration, string codeOff)
        {
            if (string.IsNullOrEmpty(registration) && !string.IsNullOrEmpty(codeOff))
            {
                isRegistrationOptional = true;
                isCodeOffOptional = false;
                codeOffPlaceholder = "Code Off";
                registrationPlaceholder = "Registration (Optional)";
            }
            else if (!string.IsNullOrEmpty(registration) && string.IsNullOrEmpty(codeOff))
            {
                isCodeOffOptional = true;
                isRegistrationOptional = false;
                codeOffPlaceholder = "Code Off (Optional)";
                registrationPlaceholder = "Registration";
            }
            else
            {
                isCodeOffOptional = false;
                isRegistrationOptional = false;
                registrationPlaceholder = "Registration";
                codeOffPlaceholder = "Code Off";
            }
        }


        #endregion
    }
}
