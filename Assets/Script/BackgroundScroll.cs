using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField]private RawImage _image;
    [SerializeField]private float _x,_y;

    // Trong Unity, Rect (viết tắt của "Rectangle") là một cấu trúc (struct) đại diện cho một hình chữ nhật.
    // Nó xác định vị trí và kích thước của một vùng chữ nhật, thường dùng để biểu diễn khu vực trên màn hình hoặc trong texture.
    //
    // Một Rect có bốn thuộc tính chính:
    //     x: Tọa độ của cạnh bên trái của hình chữ nhật theo chiều ngang.
    //     y: Tọa độ của cạnh trên của hình chữ nhật theo chiều dọc.
    //     width: Chiều rộng của hình chữ nhật.
    //     height: Chiều cao của hình chữ nhật.
    void Update()
    {
        _image.uvRect = new Rect(_image.uvRect.position + new Vector2(_x,_y) * Time.deltaTime, _image.uvRect.size);
        _y+=0.0000001f;
    }
}