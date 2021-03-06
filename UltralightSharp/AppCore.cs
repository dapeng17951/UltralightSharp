using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using ImpromptuNinjas.UltralightSharp.Enums;

namespace ImpromptuNinjas.UltralightSharp {

  [PublicAPI]
  public static unsafe class AppCore {

    static AppCore() => Native.Init();

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulCreateSettings", ExactSpelling = true)]
    [return: NativeTypeName("ULSettings")]
    public static extern Settings* CreateSettings();

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulDestroySettings", ExactSpelling = true)]
    public static extern void DestroySettings([NativeTypeName("ULSettings")] Settings* settings);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulSettingsSetDeveloperName", ExactSpelling = true)]
    public static extern void SettingsSetDeveloperName([NativeTypeName("ULSettings")] Settings* settings, [NativeTypeName("ULString")] String* name);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulSettingsSetAppName", ExactSpelling = true)]
    public static extern void SettingsSetAppName([NativeTypeName("ULSettings")] Settings* settings, [NativeTypeName("ULString")] String* name);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulSettingsSetFileSystemPath", ExactSpelling = true)]
    public static extern void SettingsSetFileSystemPath([NativeTypeName("ULSettings")] Settings* settings, [NativeTypeName("ULString")] String* path);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulSettingsSetLoadShadersFromFileSystem", ExactSpelling = true)]
    public static extern void SettingsSetLoadShadersFromFileSystem([NativeTypeName("ULSettings")] Settings* settings, OneByteBoolean enabled);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulSettingsSetForceCPURenderer", ExactSpelling = true)]
    public static extern void SettingsSetForceCpuRenderer([NativeTypeName("ULSettings")] Settings* settings, OneByteBoolean forceCpu);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulCreateApp", ExactSpelling = true)]
    [return: NativeTypeName("ULApp")]
    public static extern App* CreateApp([NativeTypeName("ULSettings")] Settings* settings, [NativeTypeName("ULConfig")] Config* config);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulDestroyApp", ExactSpelling = true)]
    public static extern void DestroyApp([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppSetWindow", ExactSpelling = true)]
    public static extern void AppSetWindow([NativeTypeName("ULApp")] App* app, [NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppGetWindow", ExactSpelling = true)]
    [return: NativeTypeName("ULWindow")]
    public static extern Window* AppGetWindow([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppSetUpdateCallback", ExactSpelling = true)]
    private static extern void AppSetUpdateCallback([NativeTypeName("ULApp")] App* app, [NativeTypeName("ULUpdateCallback")] IntPtr callback, [NativeTypeName("void *")] void* userData);

    public static void AppSetUpdateCallback([NativeTypeName("ULApp")] App* app, [NativeTypeName("ULUpdateCallback")] FnPtr<UpdateCallback> callback, [NativeTypeName("void *")] void* userData)
      => AppSetUpdateCallback(app, (IntPtr) callback, userData);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppIsRunning", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern OneByteBoolean AppIsRunning([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppGetMainMonitor", ExactSpelling = true)]
    [return: NativeTypeName("ULMonitor")]
    public static extern Monitor* AppGetMainMonitor([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppGetRenderer", ExactSpelling = true)]
    [return: NativeTypeName("ULRenderer")]
    public static extern Renderer* AppGetRenderer([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppRun", ExactSpelling = true)]
    public static extern void AppRun([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulAppQuit", ExactSpelling = true)]
    public static extern void AppQuit([NativeTypeName("ULApp")] App* app);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulMonitorGetScale", ExactSpelling = true)]
    public static extern double MonitorGetScale([NativeTypeName("ULMonitor")] Monitor* monitor);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulMonitorGetWidth", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint MonitorGetWidth([NativeTypeName("ULMonitor")] Monitor* monitor);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulMonitorGetHeight", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint MonitorGetHeight([NativeTypeName("ULMonitor")] Monitor* monitor);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulCreateWindow", ExactSpelling = true)]
    [return: NativeTypeName("ULWindow")]
    public static extern Window* CreateWindow([NativeTypeName("ULMonitor")] Monitor* monitor, [NativeTypeName("unsigned int")] uint width, [NativeTypeName("unsigned int")] uint height, OneByteBoolean fullscreen,
      [NativeTypeName("unsigned int")] WindowFlags windowFlags);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulDestroyWindow", ExactSpelling = true)]
    public static extern void DestroyWindow([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowSetCloseCallback", ExactSpelling = true)]
    private static extern void WindowSetCloseCallback([NativeTypeName("ULWindow")] Window* window, [NativeTypeName("ULCloseCallback")] IntPtr callback, [NativeTypeName("void *")] void* userData);

    public static void WindowSetCloseCallback([NativeTypeName("ULApp")] Window* window, [NativeTypeName("ULUpdateCallback")] FnPtr<UpdateCallback> callback, [NativeTypeName("void *")] void* userData)
      => WindowSetCloseCallback(window, (IntPtr) callback, userData);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowSetResizeCallback", ExactSpelling = true)]
    private static extern void WindowSetResizeCallback([NativeTypeName("ULWindow")] Window* window, [NativeTypeName("ULResizeCallback")] IntPtr callback, [NativeTypeName("void *")] void* userData);

    public static void WindowSetResizeCallback([NativeTypeName("ULApp")] Window* window, [NativeTypeName("ULResizeCallback")] FnPtr<ResizeCallback> callback, [NativeTypeName("void *")] void* userData)
      => WindowSetResizeCallback(window, (IntPtr) callback, userData);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowGetWidth", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint WindowGetWidth([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowGetHeight", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint WindowGetHeight([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowIsFullscreen", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern OneByteBoolean WindowIsFullscreen([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowGetScale", ExactSpelling = true)]
    public static extern double WindowGetScale([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowSetTitle", ExactSpelling = true)]
    public static extern void WindowSetTitle([NativeTypeName("ULWindow")] Window* window, [NativeTypeName("const char *")] sbyte* title);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowSetCursor", ExactSpelling = true)]
    public static extern void WindowSetCursor([NativeTypeName("ULWindow")] Window* window, Cursor cursor);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowClose", ExactSpelling = true)]
    public static extern void WindowClose([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowDeviceToPixel", ExactSpelling = true)]
    public static extern int WindowDeviceToPixel([NativeTypeName("ULWindow")] Window* window, int val);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowPixelsToDevice", ExactSpelling = true)]
    public static extern int WindowPixelsToDevice([NativeTypeName("ULWindow")] Window* window, int val);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulWindowGetNativeHandle", ExactSpelling = true)]
    [return: NativeTypeName("void *")]
    public static extern void* WindowGetNativeHandle([NativeTypeName("ULWindow")] Window* window);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulCreateOverlay", ExactSpelling = true)]
    [return: NativeTypeName("ULOverlay")]
    public static extern Overlay* CreateOverlay([NativeTypeName("ULWindow")] Window* window, [NativeTypeName("unsigned int")] uint width, [NativeTypeName("unsigned int")] uint height, int x, int y);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulCreateOverlayWithView", ExactSpelling = true)]
    [return: NativeTypeName("ULOverlay")]
    public static extern Overlay* CreateOverlayWithView([NativeTypeName("ULWindow")] Window* window, [NativeTypeName("ULView")] View* view, int x, int y);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulDestroyOverlay", ExactSpelling = true)]
    public static extern void DestroyOverlay([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayGetView", ExactSpelling = true)]
    [return: NativeTypeName("ULView")]
    public static extern View* OverlayGetView([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayGetWidth", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint OverlayGetWidth([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayGetHeight", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint OverlayGetHeight([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayGetX", ExactSpelling = true)]
    public static extern int OverlayGetX([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayGetY", ExactSpelling = true)]
    public static extern int OverlayGetY([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayMoveTo", ExactSpelling = true)]
    public static extern void OverlayMoveTo([NativeTypeName("ULOverlay")] Overlay* overlay, int x, int y);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayResize", ExactSpelling = true)]
    public static extern void OverlayResize([NativeTypeName("ULOverlay")] Overlay* overlay, [NativeTypeName("unsigned int")] uint width, [NativeTypeName("unsigned int")] uint height);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayIsHidden", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern OneByteBoolean OverlayIsHidden([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayHide", ExactSpelling = true)]
    public static extern void OverlayHide([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayShow", ExactSpelling = true)]
    public static extern void OverlayShow([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayHasFocus", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern OneByteBoolean OverlayHasFocus([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayFocus", ExactSpelling = true)]
    public static extern void OverlayFocus([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulOverlayUnfocus", ExactSpelling = true)]
    public static extern void OverlayUnfocus([NativeTypeName("ULOverlay")] Overlay* overlay);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulEnablePlatformFontLoader", ExactSpelling = true)]
    public static extern void EnablePlatformFontLoader();

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulEnablePlatformFileSystem", ExactSpelling = true)]
    public static extern void EnablePlatformFileSystem([NativeTypeName("ULString")] String* baseDir);

    [DllImport("AppCore", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ulEnableDefaultLogger", ExactSpelling = true)]
    public static extern void EnableDefaultLogger([NativeTypeName("ULString")] String* logPath);

  }

  namespace Safe {

    public static unsafe class AppCore {

      public static void EnablePlatformFontLoader()
        => UltralightSharp.AppCore.EnablePlatformFontLoader();

      public static void EnablePlatformFileSystem(string baseDir) {
        var s = String.Create(baseDir);
        UltralightSharp.AppCore.EnablePlatformFileSystem(s);
        s->Destroy();
      }

      public static void EnableDefaultLogger(string logPath) {
        var s = String.Create(logPath);
        UltralightSharp.AppCore.EnableDefaultLogger(s);
        s->Destroy();
      }

    }

  }

}