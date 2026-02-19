namespace MauiTestApp.Views.Graphics;

/// <summary>
/// Custom IDrawable that demonstrates MAUI Graphics drawing capabilities:
/// shapes, fills, strokes, gradients, and paths.
/// </summary>
public class GraphicsDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var width = dirtyRect.Width;
        var height = dirtyRect.Height;

        // Filled circle with stroke
        canvas.StrokeColor = Colors.DarkSlateBlue;
        canvas.StrokeSize = 3;
        canvas.FillColor = Color.FromArgb("#512BD4");
        canvas.FillCircle(60, 60, 40);
        canvas.DrawCircle(60, 60, 40);

        // Rounded rectangle with gradient
        var gradientPaint = new LinearGradientPaint
        {
            StartColor = Color.FromArgb("#FF6B6B"),
            EndColor = Color.FromArgb("#4ECDC4"),
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 1)
        };
        canvas.SetFillPaint(gradientPaint, new RectF(130, 20, 120, 80));
        canvas.FillRoundedRectangle(130, 20, 120, 80, 12);
        canvas.StrokeColor = Colors.Gray;
        canvas.StrokeSize = 2;
        canvas.DrawRoundedRectangle(130, 20, 120, 80, 12);

        // Star shape using path
        canvas.FillColor = Color.FromArgb("#FFD700");
        canvas.StrokeColor = Color.FromArgb("#DAA520");
        canvas.StrokeSize = 2;

        var path = new PathF();
        float cx = width > 340 ? 320 : width - 50;
        float cy = 60;
        float outerR = 35;
        float innerR = 15;

        for (int i = 0; i < 5; i++)
        {
            float outerAngle = (float)(Math.PI / 2 + i * 2 * Math.PI / 5);
            float innerAngle = (float)(Math.PI / 2 + (i + 0.5) * 2 * Math.PI / 5);

            float ox = cx + outerR * (float)Math.Cos(outerAngle);
            float oy = cy - outerR * (float)Math.Sin(outerAngle);
            float ix = cx + innerR * (float)Math.Cos(innerAngle);
            float iy = cy - innerR * (float)Math.Sin(innerAngle);

            if (i == 0)
                path.MoveTo(ox, oy);
            else
                path.LineTo(ox, oy);

            path.LineTo(ix, iy);
        }
        path.Close();

        canvas.FillPath(path);
        canvas.DrawPath(path);

        // Bezier curve
        canvas.StrokeColor = Color.FromArgb("#E91E63");
        canvas.StrokeSize = 3;
        canvas.StrokeLineCap = LineCap.Round;

        float curveY = height > 150 ? 140 : height - 20;
        canvas.DrawCurve(20, curveY, 80, curveY - 60, 160, curveY + 40, width - 20, curveY - 20);

        // Label for curve
        canvas.FontColor = Colors.Gray;
        canvas.FontSize = 11;
        canvas.DrawString("Bezier Curve", 20, curveY + 10, 200, 20, HorizontalAlignment.Left, VerticalAlignment.Top);
    }
}
