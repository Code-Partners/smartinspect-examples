object Form1: TForm1
  Left = 192
  Top = 175
  Caption = 'Form1'
  ClientHeight = 68
  ClientWidth = 289
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 253
    Height = 13
    Caption = 'Paste your write key to WriteKey constant in the code'
  end
  object Button1: TButton
    Left = 206
    Top = 35
    Width = 75
    Height = 25
    Caption = 'Send'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 8
    Top = 37
    Width = 177
    Height = 21
    TabOrder = 1
    Text = 'Test message'
  end
end
