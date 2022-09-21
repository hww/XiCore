// =============================================================================
// MIT License
// 
// Copyright (c) 2018 Valeriya Pudova (hww.github.io)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// =============================================================================


using UnityEngine;
using XiCore.UnityTiming;

public class FpsCounterScene : MonoBehaviour
{
    public bool isVisible = true;

    private string _text;

    #region Static Private Vars

    private static GUISkin _skin;
    #endregion

    void OnEnable()
    {
        _skin = Resources.Load<GUISkin>("XiCore/Skins/Default Skin");
        FpsCounterData config = new FpsCounterData{
            showFpsHud = true,
            showFpsMinMax = true
        };
        FpsCounter.Initialize(config);
    }

    private void Update()
    {
        if (FpsCounter.OnUpdate(Time.unscaledDeltaTime))
        {
            if (isVisible)
            {
                if (FpsCounter.ShowFpsMinMax)
                    _text = $"{FpsCounter.Fps} fps\n{FpsCounter.MinFps} min\n{FpsCounter.MaxFps} max";
                else
                    _text = $"{FpsCounter.Fps} fps";
            }
        }
    }

    private void FixedUpdate()
    {
        FpsCounter.OnFixedUpdate();
    }

    // Render the FSP counter
    void OnGUI()
    {
        if (!isVisible)
            return;

        GUI.skin = _skin;

        var textSize = GUI.skin.label.CalcSize(new GUIContent(_text)) + new Vector2(10, 10);
        var position = new Vector2(Screen.width - 20 - textSize.x, 20);
        var rect = new Rect(position, textSize);

        GUI.Box(rect, GUIContent.none);

        rect.x += 5f;
        rect.width -= 5f * 2f;
        rect.y += 5f;
        rect.height -= 5f * 2f;

        GUI.Label(rect, _text);
    }
}
