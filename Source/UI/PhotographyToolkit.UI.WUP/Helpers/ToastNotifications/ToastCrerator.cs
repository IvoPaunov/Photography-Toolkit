namespace PhotographyToolkit.UI.WUP.Helpers.ToastNotifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NotificationsExtensions.Toasts;
    using PhotographyToolkit.Common.Extensions;

    public static class ToastCrerator
    {
        public static ToastVisual GetVisualToast(
            string title,
            string contentFirstLine,
            string contentSecondLine,
            IEnumerable<string> imagesPaths = null,
            string logoPath = null)
        {
            var result = new ToastVisual();

            if (title != null)
            {
                result.TitleText = new ToastText()
                {
                    Text = title
                };
            }

            if (contentFirstLine != null)
            {
                result.BodyTextLine1 = new ToastText()
                {
                    Text = contentFirstLine
                };
            }

            if (contentSecondLine != null)
            {
                result.BodyTextLine2 = new ToastText()
                {
                    Text = contentSecondLine
                };
            }

            if (imagesPaths != null && imagesPaths.Count() <= 6)
            {
                imagesPaths
                    .ForEach(i => 
                        result.InlineImages.Add(new ToastImage()
                            {
                                Source = new ToastImageSource(i)
                            }));
            }

            if (logoPath != null)
            {
                result.AppLogoOverride = new ToastAppLogo()
                {
                    Source = new ToastImageSource(logoPath)
                };
            }

            return result;
        }

        public static ToastActionsCustom GetToastCustomActions(IEnumerable<IToastInput> textBoxes, IEnumerable<IToastButton> buttons, string aurioUri = null)
        {
            ToastActionsCustom actions = new ToastActionsCustom();

            if (textBoxes != null && textBoxes.Count() <= 5)
            {
                textBoxes.ForEach(tb => actions.Inputs.Add(tb));
            }

            if (buttons != null && buttons.Count() <= 5)
            {
                buttons.ForEach(tb => actions.Buttons.Add(tb));
            }

            return actions;
        }

        public static ToastContent GetToastContent(ToastVisual visual, ToastActionsCustom actions)
        {
            var content = new ToastContent();

            if (visual != null)
            {
                content.Visual = visual;
            }

            if (actions != null)
            {
                content.Actions = actions;
            }

            //content.Audio = new ToastAudio()
            //{
            //    Src = new Uri("ms-winsoundevent:Notification.IM")
            //};

            return content;
        }

    }
}
