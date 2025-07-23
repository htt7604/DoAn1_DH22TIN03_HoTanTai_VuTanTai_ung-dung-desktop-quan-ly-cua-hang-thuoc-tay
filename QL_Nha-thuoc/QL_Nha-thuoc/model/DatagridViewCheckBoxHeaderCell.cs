using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

public class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
{
    Point checkBoxLocation;
    Size checkBoxSize;
    bool _checked = false;
    Point _cellLocation = new Point();
    CheckBoxState _cbState = CheckBoxState.UncheckedNormal;

    public event Action<bool> OnCheckAllChanged;

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
        int rowIndex, DataGridViewElementStates dataGridViewElementState,
        object value, object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        base.Paint(graphics, clipBounds, cellBounds, rowIndex,
            dataGridViewElementState, value, formattedValue, errorText,
            cellStyle, advancedBorderStyle, paintParts);

        Point p = new Point();
        Size s = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
        p.X = cellBounds.X + (cellBounds.Width / 2) - (s.Width / 2);
        p.Y = cellBounds.Y + (cellBounds.Height / 2) - (s.Height / 2);
        _cellLocation = cellBounds.Location;
        checkBoxLocation = p;
        checkBoxSize = s;

        CheckBoxRenderer.DrawCheckBox(graphics, checkBoxLocation, _checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
    }

    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        base.OnMouseClick(e);

        Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
        Rectangle rect = new Rectangle(checkBoxLocation, checkBoxSize);
        if (rect.Contains(p))
        {
            _checked = !_checked;
            if (this.DataGridView != null)
                this.DataGridView.InvalidateCell(this);
            OnCheckAllChanged?.Invoke(_checked);
        }
    }
}
