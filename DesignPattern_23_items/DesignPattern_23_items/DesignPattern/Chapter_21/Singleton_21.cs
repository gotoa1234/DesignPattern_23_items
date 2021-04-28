namespace DesignPattern_23_items.DesignPattern.Chapter_21
{
    /// <summary>
    /// 【單例模式】Singleton 創建型模式
    /// <para>
    /// 保證一個類僅有一個實例，並提供一個訪問它的全局訪問點
    /// </para>
    /// </summary>
    internal class Singleton_21
    {
    }

    public sealed class Singleton
    {
        public static Singleton GetInstance { get; } = new Singleton();
    }
}