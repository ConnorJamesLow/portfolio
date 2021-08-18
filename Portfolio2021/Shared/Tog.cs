
namespace Portfolio2021.Shared;
public class Tog
{
    public event Action<bool>? OnToggle;

    public bool IsActive { get; set; }
    public void Toggle()
    {
        IsActive = !IsActive;
        if (OnToggle != default)
        {
            OnToggle(IsActive);
        }
    }

    public T? Then<T>(T value) => IsActive ? value : (typeof(T).IsAssignableFrom(typeof(string)) ? (T)(object)"" : default);

    public static implicit operator bool(Tog value) => value.IsActive;
}
