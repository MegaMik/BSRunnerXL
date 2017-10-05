Namespace vbAccelerator.Components.Controls

    ''' <summary>
    ''' A simple implementation of a Virtual ListBox.  A virtual ListBox
    ''' contains no data, instead it just allocates space for a specified
    ''' number of rows.  Whenever a row needs to be shown, the "OnDrawItem"
    ''' method is fired which in turn fires the "DrawItem" event.
    ''' </summary>
    Public Class VListBox
        Inherits System.Windows.Forms.ListBox

        '/*
        '* Listbox Styles
        '*/
        Private Const LBS_NOTIFY As Integer = &H1
        Private Const LBS_SORT As Integer = &H2
        Private Const LBS_NOREDRAW As Integer = &H4
        Private Const LBS_MULTIPLESEL As Integer = &H8
        Private Const LBS_OWNERDRAWFIXED As Integer = &H10
        Private Const LBS_OWNERDRAWVARIABLE As Integer = &H20
        Private Const LBS_HASSTRINGS As Integer = &H40
        Private Const LBS_USETABSTOPS As Integer = &H80
        Private Const LBS_NOINTEGRALHEIGHT As Integer = &H100
        Private Const LBS_MULTICOLUMN As Integer = &H200
        Private Const LBS_WANTKEYBOARDINPUT As Integer = &H400
        Private Const LBS_EXTENDEDSEL As Integer = &H800
        Private Const LBS_DISABLENOSCROLL As Integer = &H1000
        Private Const LBS_NODATA As Integer = &H2000

        Private Const LB_GETCOUNT As Integer = &H18B
        Private Const LB_SETCOUNT As Integer = &H1A7

        Private Const LB_SETSEL As Integer = &H185
        Private Const LB_SETCURSEL As Integer = &H186
        Private Const LB_GETSEL As Integer = &H187
        Private Const LB_GETCURSEL As Integer = &H188
        Private Const LB_GETSELCOUNT As Integer = &H190
        Private Const LB_GETSELITEMS As Integer = &H191

        Private Declare Auto Function SendMessage Lib "user32" ( _
               ByVal hWnd As IntPtr, _
               ByVal msg As Integer, _
               ByVal wParam As Integer, _
               ByVal lParam As IntPtr) As Integer

#Region "Member Variables"
        Private m_selectedIndex As Integer = -1
        Private m_selectedIndices As VListBox.SelectedIndexCollection = Nothing
#End Region


        ''' <summary>
        ''' Constructs a new instance of this class.
        ''' </summary>
        Public Sub New()
            MyBase.New()
            m_selectedIndices = New VListBox.SelectedIndexCollection(Me)
        End Sub

        Public Sub DefaultDrawItem( _
            ByVal e As DrawItemEventArgs, _
            ByVal text As String _
            )
            Dim selected As Boolean = ((e.State And DrawItemState.Selected) = DrawItemState.Selected)

            If (selected) Then
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds)
            Else
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds)
            End If

            e.Graphics.DrawString( _
                text, _
                 Me.Font, _
                IIf(selected, SystemBrushes.HighlightText, SystemBrushes.WindowText), _
                New RectangleF(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2))
        End Sub

        ''' <summary>
        ''' Gets or sets the number of virtual items in the ListBox.
        ''' </summary>
        Public Property Count() As Integer
            Get
                Return SendMessage(Me.Handle, LB_GETCOUNT, 0, IntPtr.Zero)
            End Get
            Set(ByVal Value As Integer)
                SendMessage(Me.Handle, LB_SETCOUNT, Value, IntPtr.Zero)
            End Set
        End Property

        ''' <summary>
        ''' Gets/sets the DrawMode of the ListBox.  The DrawMode must always
        ''' be set to <see cref="System.Windows.Forms.DrawMode.OwnerDrawFixed"/>.
        ''' </summary>
        <System.ComponentModel.Browsable(False)> _
        Public Shadows Property DrawMode() As System.Windows.Forms.DrawMode
            Get
                Return System.Windows.Forms.DrawMode.OwnerDrawFixed
            End Get
            Set(ByVal Value As System.Windows.Forms.DrawMode)
                If Not (Value = System.Windows.Forms.DrawMode.OwnerDrawFixed) Then
                    Throw New ArgumentException("DrawMode must be set to OwnerDrawFixed in a Virtual ListBox")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Throws an exception.  All the items for a Virtual ListBox are externally managed.
        ''' </summary>
        <System.ComponentModel.BrowsableAttribute(False)> _
        Public Shadows ReadOnly Property Items() As ObjectCollection
            Get
                'Throw New InvalidOperationException("A Virtual ListBox does not have an Items collection.")
                Return New ObjectCollection(New ListBox)
            End Get
        End Property

        ''' <summary>
        ''' Throws an exception.  All the items for a Virtual ListBox are externally managed.
        ''' </summary>
        ''' <remarks>The selected index can be obtained using the <see cref="SelectedIndex"/> and
        ''' <see cref="SelectedIndices"/> properties.
        ''' </remarks>
        <System.ComponentModel.BrowsableAttribute(False)> _
        Public Shadows ReadOnly Property SelectedItems() As SelectedObjectCollection
            Get
                Throw New InvalidOperationException("A Virtual ListBox does not have a SelectedObject collection")
            End Get
        End Property

        ''' <summary>
        ''' Hides the Sorted property of the ListBox control.  Any attempt to set this property
        ''' to true will result in an exception.
        ''' </summary>
        <System.ComponentModel.BrowsableAttribute(False)> _
        Public Shadows Property Sorted() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
                If (Value) Then
                    Throw New InvalidOperationException("A Virtual ListBox cannot be sorted.")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Returns the selected index in the control.  If the control has the multi-select
        ''' style, then the first selected item is returned.
        ''' </summary>
        Public Shadows Property SelectedIndex() As Integer
            Get
                Dim selIndex As Integer = -1
                If (SelectionMode = System.Windows.Forms.SelectionMode.One) Then
                    selIndex = SendMessage(Me.Handle, LB_GETCURSEL, 0, IntPtr.Zero)
                ElseIf ((SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended) Or _
                 (SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple)) Then
                    Dim selCount As Integer = SendMessage(Me.Handle, LB_GETSELCOUNT, 0, IntPtr.Zero)
                    If (selCount > 0) Then
                        Dim buf As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(4)
                        SendMessage(Me.Handle, LB_GETSELITEMS, 1, buf)
                        selIndex = System.Runtime.InteropServices.Marshal.ReadInt32(buf)
                        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(buf)
                    End If
                End If
                Return selIndex
            End Get
            Set(ByVal Value As Integer)
                If (SelectionMode = System.Windows.Forms.SelectionMode.One) Then
                    SendMessage(Me.Handle, LB_SETCURSEL, Value, IntPtr.Zero)
                ElseIf ((SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended) Or _
                 (SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple)) Then
                    Console.WriteLine("Working on it")
                End If
            End Set
        End Property

        ''' <summary>
        '''  todo
        ''' </summary>
        Public Shadows ReadOnly Property SelectedIndices() As SelectedIndexCollection
            Get
                Return m_selectedIndices
            End Get
        End Property

        ''' <summary>
        ''' Gets the selection state for an item.
        ''' </summary>
        ''' <param name="index">Index of the item.</param>
        ''' <returns><c>true</c> if selected, <c>false</c> otherwise.</returns>
        Public Function ItemSelected(ByVal index As Integer) As Boolean
            Dim state As Boolean = False
            If (SelectionMode = System.Windows.Forms.SelectionMode.One) Then
                state = (SelectedIndex = index)
            ElseIf ((SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended) Or _
             (SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple)) Then
                state = (SendMessage(Me.Handle, LB_GETSEL, index, IntPtr.Zero) <> 0)
            End If
            Return state
        End Function

        ''' <summary>
        ''' Sets the selection state for an item.
        ''' </summary>
        ''' <param name="index">Index of the item.</param>
        ''' <param name="state">New selection state for the item.</param>
        Public Sub ItemSelected(ByVal index As Integer, ByVal state As Boolean)
            If (SelectionMode = System.Windows.Forms.SelectionMode.One) Then
                If (state) Then
                    SelectedIndex = index
                End If
            ElseIf ((SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended) Or _
                 (SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple)) Then
                Dim theIndex As IntPtr = New IntPtr(index)
                SendMessage(Me.Handle, LB_SETSEL, IIf(state, 1, 0), theIndex)
            End If
        End Sub

        ''' <summary>
        ''' Called when an item in the control needs to be drawn, and raises the 
        ''' <see cref="DrawItem"/> event.
        ''' </summary>
        ''' <param name="e">Details about the item that is to be drawn.</param>
        Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
            If ((e.State And DrawItemState.Selected) = DrawItemState.Selected) Then
                m_selectedIndex = e.Index
            End If
            MyBase.OnDrawItem(e)
        End Sub

        ''' <summary>
        ''' Sets up the <see cref="CreateParams"/> object to tell Windows
        ''' how the ListBox control should be created.  In this instance
        ''' the default configuration is modified to remove <c>LBS_HASSTRINGS</c>
        ''' and <c>LBS_SORT</c> styles and to add <c>LBS_NODATA</c>
        ''' and <c>LBS_OWNERDRAWFIXED</c> styles. This converts the ListBox
        ''' into a Virtual ListBox.
        ''' </summary>
        Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
            Get
                Dim defParams As CreateParams = MyBase.CreateParams
                Console.WriteLine("In Param style: {0:X8}", defParams.Style)
                defParams.Style = defParams.Style And Not LBS_HASSTRINGS
                defParams.Style = defParams.Style And Not LBS_SORT
                defParams.Style = defParams.Style Or LBS_OWNERDRAWFIXED Or LBS_NODATA
                Console.WriteLine("Out Param style: {0:X8}", defParams.Style)
                Return defParams
            End Get
        End Property

        ''' <summary>
        ''' Called when the ListBox handle is destroyed.  
        ''' </summary>
        ''' <param name="e">Not used</param>
        Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
            '// Nasty.  The problem is with the call to NativeUpdateSelection,
            '// which calls the EnsureUpToDate on the SelectedObjectCollection method, 
            '// and that is broken.
            Try
                MyBase.OnHandleDestroyed(e)
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>
        ''' Implements a read-only collection of selected items in the
        ''' VListBox.
        ''' </summary>
        Public Shadows Class SelectedIndexCollection
            Implements ICollection, IEnumerable

            Private owner As VListBox = Nothing

            ''' <summary>
            ''' Creates a new instance of this class
            ''' </summary>
            ''' <param name="owner">The VListBox which owns the collection</param>
            Public Sub New(ByVal owner As VListBox)
                Me.owner = owner
            End Sub

            ''' <summary>
            ''' Returns an enumerator which allows iteration through the selected items
            ''' collection.
            ''' </summary>
            ''' <returns></returns>
            Public Function GetEnumerator() As IEnumerator _
                Implements System.Collections.IEnumerable.GetEnumerator
                Return New SelectedIndexCollectionEnumerator(Me.owner)
            End Function

            ''' <summary>
            ''' Not implemented. Throws an exception.
            ''' </summary>
            ''' <param name="dest">Array to copy items to</param>
            ''' <param name="startIndex">First index in array to put items in.</param>
            Public Sub CopyTo(ByVal dest As Array, ByVal startIndex As Integer) _
                Implements System.Collections.ICollection.CopyTo
                Throw New InvalidOperationException("Not implemented")
            End Sub

            ''' <summary>
            ''' Returns the number of items in the collection.
            ''' </summary>
            Public ReadOnly Property Count() As Integer _
                Implements System.Collections.ICollection.Count
                Get
                    Return SendMessage(owner.Handle, LB_GETSELCOUNT, 0, IntPtr.Zero)
                End Get
            End Property

            ''' <summary>
            ''' Returns the selected item with the specified 0-based index in the collection
            ''' of selected items.  
            ''' </summary>
            ''' <remarks>
            ''' Do not use this method to enumerate through all selected
            ''' items as it gets the collection of selected items each item it 
            ''' is called.  The <c>foreach</c> enumerator only gets the collection
            ''' of items once when it is constructed and is therefore quicker.
            ''' </remarks>
            Default Public ReadOnly Property Item(ByVal index As Integer) As Object
                Get
                    Dim selIndex As Integer = -1
                    Dim selCount As Integer = SendMessage(owner.Handle, LB_GETSELCOUNT, 0, IntPtr.Zero)
                    If ((index < selCount) And (index > 0)) Then
                        Dim buf As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(4 * (index + 1))
                        SendMessage(owner.Handle, LB_GETSELITEMS, selCount, buf)
                        selIndex = System.Runtime.InteropServices.Marshal.ReadInt32(buf, index * 4)
                        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(buf)
                    Else
                        Throw New ArgumentException("Index out of bounds", "index")
                    End If
                    Return selIndex
                End Get
            End Property

            ''' <summary>
            ''' Returns <c>false</c>.  This collection is not synchronized for
            ''' concurrent access from multiple threads.
            ''' </summary>
            Public ReadOnly Property IsSynchronized() As Boolean _
                Implements ICollection.IsSynchronized
                Get
                    Return False
                End Get
            End Property

            ''' <summary>
            ''' Not implemented. Throws an exception.
            ''' </summary>
            Public ReadOnly Property SyncRoot() As Object _
                Implements ICollection.SyncRoot
                Get
                    Throw New InvalidOperationException("Synchronization not supported.")
                End Get
            End Property


        End Class

        ''' <summary>
        ''' Implements the "IEnumerator" interface for the selected indexes
        ''' within a <see cref="VListBox"/> control.
        ''' </summary>
        Public Class SelectedIndexCollectionEnumerator
            Implements IEnumerator, IDisposable

            Private buf As IntPtr = IntPtr.Zero
            Private size As Integer = 0
            Private offset As Integer = 0

            ''' <summary>
            ''' Constructs a new instance of this class.
            ''' </summary>
            ''' <param name="owner">The <see cref="VListBox"/> which owns the collection.</param>
            Public Sub New(ByVal owner As VListBox)
                Dim selCount As Integer = SendMessage(owner.Handle, LB_GETSELCOUNT, 0, IntPtr.Zero)
                If (selCount > 0) Then
                    buf = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(4 * selCount)
                    SendMessage(owner.Handle, LB_GETSELITEMS, selCount, buf)
                End If
            End Sub

            ''' <summary>
            ''' Clears up any resources associated with this enumerator.
            ''' </summary>
            Public Sub Dispose() _
                Implements IDisposable.Dispose
                If (Not (buf.Equals(IntPtr.Zero))) Then
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(buf)
                    buf = IntPtr.Zero
                End If
            End Sub

            ''' <summary>
            ''' Resets the enumerator to the start of the list.
            ''' </summary>
            Public Sub Reset() _
                Implements IEnumerator.Reset
                offset = 0
            End Sub

            ''' <summary>
            ''' Returns the current object.
            ''' </summary>
            Public ReadOnly Property Current() As Object _
                Implements IEnumerator.Current
                Get
                    If (offset >= size) Then
                        Throw New Exception("Collection is exhausted.")
                    Else
                        Dim index As Integer = System.Runtime.InteropServices.Marshal.ReadInt32(buf, offset * 4)
                        Dim ret As Object
                        ret = index
                        Return ret
                    End If
                End Get
            End Property

            ''' <summary>
            ''' Advances the enumerator to the next element of the collection.
            ''' </summary>
            ''' <returns><c>true</c> if the enumerator was successfully advanced to the next element; 
            ''' <c>false</c> if the enumerator has passed the end of the collection.</returns>
            Public Function MoveNext() As Boolean _
                Implements IEnumerator.MoveNext

                Dim success As Boolean = False
                offset += 1
                If (offset < size) Then
                    success = True
                End If
                Return success
            End Function
        End Class


    End Class


End Namespace

