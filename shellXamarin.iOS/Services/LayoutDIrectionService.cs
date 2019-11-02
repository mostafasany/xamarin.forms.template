using System;
using Xamarin.Forms;
using shellXamarin.iOS;

using ObjCRuntime;
using System.Runtime.InteropServices;
using UIKit;
using System.Diagnostics;
using shellXamarin.Module.Common.Services;

[assembly: Dependency(typeof(LayoutDIrectionService))]

namespace shellXamarin.iOS
{
    public class LayoutDIrectionService : ILayoutDIrectionService
    {
        [DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]

        
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);
        //internal extern static IntPtr IntPtr_objcText_msgSend(IntPtr receiver, IntPtr selector, UITextAlignment arg1);

        public LayoutDIrectionService()
        {

        }
        public void SetLayoutRTL()
        {
            try
            {
                Selector selector = new Selector("setSemanticContentAttribute:");
                IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceRightToLeft);
          
                

            }
            catch (Exception s)
            {
                Debug.WriteLine("failed to set layout...." + s.Message.ToString());
            }
        }
        public void SetLayoutLTR()
        {
            try
            {
                Selector selector = new Selector("setSemanticContentAttribute:");
                IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceLeftToRight);


            }
            catch (Exception s)
            {
                Debug.WriteLine("failed to set layout...." + s.Message.ToString());
            }
        }
    }
}

