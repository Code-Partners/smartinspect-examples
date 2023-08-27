(*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the most used features of the 
 *  SmartInspect Delphi library. Each page features another 
 *  part of the SmartInspect Delphi library functionality.
 *
 *)

unit MainUnit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, ExtCtrls, StdCtrls, ShellApi,
{$IFDEF VER150} // Delphi 7
  SmartInspect
{$ELSE}
  SmartInspect.VCL.SiAuto, SmartInspect.VCL, SmartInspect.Core;
{$ENDIF}


type
  TMainForm = class(TForm)
    PageControl: TPageControl;
    InformationTabSheet: TTabSheet;
    GeneralTabSheet: TTabSheet;
    ValuesTabSheet: TTabSheet;
    CloseButton: TButton;
    InfoLabel: TLabel;
    AdvancedLabel: TLabel;
    MessageLabel: TLabel;
    WarningLabel: TLabel;
    ErrorLabel: TLabel;
    MessageEdit: TEdit;
    WarningEdit: TEdit;
    ErrorEdit: TEdit;
    LogMessageButton: TButton;
    LogWarningButton: TButton;
    LogErrorButton: TButton;
    Bevel1: TBevel;
    EnterMethodLabel: TLabel;
    EnterMethodEdit: TEdit;
    LeaveMethodLabel: TLabel;
    LeaveMethodEdit: TEdit;
    LeaveMethodButton: TButton;
    EnterMethodButton: TButton;
    Bevel2: TBevel;
    LogSeparatorButton: TButton;
    AddCheckpointButton: TButton;
    ResetCheckpointButton: TButton;
    ErrorMemo: TMemo;
    StringLabel: TLabel;
    IntegerLabel: TLabel;
    CharLabel: TLabel;
    DoubleLabel: TLabel;
    LogExceptionButton: TButton;
    StringEdit: TEdit;
    CharEdit: TEdit;
    IntegerEdit: TEdit;
    DoubleEdit: TEdit;
    StringLogButton: TButton;
    CharLogButton: TButton;
    IntegerLogButton: TButton;
    DoubleLogButton: TButton;
    ValuesLabel: TLabel;
    IntegerWatchButton: TButton;
    StringWatchButton: TButton;
    CharWatchButton: TButton;
    DoubleWatchButton: TButton;
    SourceTabSheet: TTabSheet;
    SourceFormatLabel: TLabel;
    SourceFormatEdit: TComboBox;
    SourceMemo: TMemo;
    LogSourceButton: TButton;
    PictureTabSheet: TTabSheet;
    LogImageButton: TButton;
    MiscTabSheet: TTabSheet;
    LogObjectLabel: TLabel;
    LogObjectButton: TButton;
    Bevel3: TBevel;
    SystemLabel: TLabel;
    LogSystemButton: TButton;
    LogMemoryLabel: TLabel;
    LogMemoryButton: TButton;
    Bevel4: TBevel;
    ScreenshotLabel: TLabel;
    WindowScreenshotButton: TButton;
    DesktopScreenshotButton: TButton;
    Image: TImage;
    procedure CloseButtonClick(Sender: TObject);
    procedure WebsiteLabelClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure LogMessageButtonClick(Sender: TObject);
    procedure LogWarningButtonClick(Sender: TObject);
    procedure LogErrorButtonClick(Sender: TObject);
    procedure EnterMethodButtonClick(Sender: TObject);
    procedure LeaveMethodButtonClick(Sender: TObject);
    procedure LogSeparatorButtonClick(Sender: TObject);
    procedure AddCheckpointButtonClick(Sender: TObject);
    procedure ResetCheckpointButtonClick(Sender: TObject);
    procedure LogExceptionButtonClick(Sender: TObject);
    procedure DoubleLogButtonClick(Sender: TObject);
    procedure IntegerLogButtonClick(Sender: TObject);
    procedure CharLogButtonClick(Sender: TObject);
    procedure StringLogButtonClick(Sender: TObject);
    procedure StringWatchButtonClick(Sender: TObject);
    procedure CharWatchButtonClick(Sender: TObject);
    procedure IntegerWatchButtonClick(Sender: TObject);
    procedure DoubleWatchButtonClick(Sender: TObject);
    procedure LogSourceButtonClick(Sender: TObject);
    procedure LogImageButtonClick(Sender: TObject);
    procedure LogObjectButtonClick(Sender: TObject);
    procedure LogMemoryButtonClick(Sender: TObject);
    procedure LogSystemButtonClick(Sender: TObject);
    procedure WindowScreenshotButtonClick(Sender: TObject);
    procedure DesktopScreenshotButtonClick(Sender: TObject);
  private
    procedure SmartInspectError(ASender: TSmartInspect;
      AException: Exception);
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.dfm}

procedure TMainForm.CloseButtonClick(Sender: TObject);
begin
  Close;
end;

procedure TMainForm.WebsiteLabelClick(Sender: TObject);
begin
  ShellExecute(Handle, 'open', 'http://www.gurock.com/', '', '', SW_SHOW);
end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  Si.OnError := SmartInspectError;
  Si.Enabled := True;
end;

procedure TMainForm.SmartInspectError(ASender: TSmartInspect;
  AException: Exception);
begin
  ErrorMemo.Lines.Add(AException.Message);
  ErrorMemo.Lines.Add('');
  ErrorMemo.Lines.Add('If the SmartInspect Console is not running, please ' +
    'start the SmartInspect Console and restart this example application.');
end;

procedure TMainForm.LogMessageButtonClick(Sender: TObject);
begin
  SiMain.LogMessage(MessageEdit.Text);
end;

procedure TMainForm.LogWarningButtonClick(Sender: TObject);
begin
  SiMain.LogWarning(WarningEdit.Text);
end;

procedure TMainForm.LogErrorButtonClick(Sender: TObject);
begin
  SiMain.LogError(ErrorEdit.Text);
end;

procedure TMainForm.EnterMethodButtonClick(Sender: TObject);
begin
  SiMain.EnterMethod(Self, EnterMethodEdit.Text);
end;

procedure TMainForm.LeaveMethodButtonClick(Sender: TObject);
begin
  SiMain.LeaveMethod(Self, LeaveMethodEdit.Text);
end;

procedure TMainForm.LogSeparatorButtonClick(Sender: TObject);
begin
  SiMain.LogSeparator;
end;

procedure TMainForm.AddCheckpointButtonClick(Sender: TObject);
begin
  SiMain.AddCheckpoint;
end;

procedure TMainForm.ResetCheckpointButtonClick(Sender: TObject);
begin
  SiMain.ResetCheckpoint;
end;

procedure TMainForm.LogExceptionButtonClick(Sender: TObject);
var
  N: Integer;
begin
  try
    N := 0;
    N := 125 div N;
    ShowMessage(IntToStr(N));
  except
    SiMain.LogException;
  end;
end;

procedure TMainForm.DoubleLogButtonClick(Sender: TObject);
begin
  FormatSettings.DecimalSeparator := '.';
  SiMain.LogDouble('Double', StrToFloat(DoubleEdit.Text));
end;

procedure TMainForm.IntegerLogButtonClick(Sender: TObject);
begin
  SiMain.LogInteger('Integer', StrToInt(IntegerEdit.Text));
end;

procedure TMainForm.CharLogButtonClick(Sender: TObject);
begin
  if Length(CharEdit.Text) > 0 then
    SiMain.LogChar('Char', CharEdit.Text[1]);
end;

procedure TMainForm.StringLogButtonClick(Sender: TObject);
begin
  SiMain.LogString('String', StringEdit.Text);
end;

procedure TMainForm.StringWatchButtonClick(Sender: TObject);
begin
  SiMain.WatchString('String', StringEdit.Text);
end;

procedure TMainForm.CharWatchButtonClick(Sender: TObject);
begin
  if Length(CharEdit.Text) > 0 then
    SiMain.WatchChar('Char', CharEdit.Text[1]);
end;

procedure TMainForm.IntegerWatchButtonClick(Sender: TObject);
begin
  SiMain.WatchInteger('Integer', StrToInt(IntegerEdit.Text));
end;

procedure TMainForm.DoubleWatchButtonClick(Sender: TObject);
begin
  FormatSettings.DecimalSeparator := '.';
  SiMain.WatchDouble('Double', StrToFloat(DoubleEdit.Text));
end;

procedure TMainForm.LogSourceButtonClick(Sender: TObject);
begin
  case SourceFormatEdit.ItemIndex of
    0: SiMain.LogSource('HTML', SourceMemo.Lines.Text, siHtml);
    1: SiMain.LogSource('JavaScript', SourceMemo.Lines.Text, siJavaScript);
    2: SiMain.LogSource('VB Script', SourceMemo.Lines.Text, siVbScript);
    3: SiMain.LogSource('Perl', SourceMemo.Lines.Text, siPerl);
    4: SiMain.LogSource('SQL', SourceMemo.Lines.Text, siSql);
    5: SiMain.LogSource('INI File', SourceMemo.Lines.Text, siIni);
    6: SiMain.LogSource('Python', SourceMemo.Lines.Text, siPython);
    7: SiMain.LogSource('Xml', SourceMemo.Lines.Text, siXml);
  end;
end;

procedure TMainForm.LogImageButtonClick(Sender: TObject);
begin
  SiMain.LogPicture('Picture', Image.Picture);
end;

procedure TMainForm.LogObjectButtonClick(Sender: TObject);
begin
  SiMain.LogObject('MainForm', Self);
end;

procedure TMainForm.LogMemoryButtonClick(Sender: TObject);
begin
  SiMain.LogMemoryStatistic;
end;

procedure TMainForm.LogSystemButtonClick(Sender: TObject);
begin
  SiMain.LogSystem;
end;

procedure TMainForm.WindowScreenshotButtonClick(Sender: TObject);
begin
  SiMain.LogScreenshot('Main Window Screenshot', Handle);
end;

procedure TMainForm.DesktopScreenshotButtonClick(Sender: TObject);
begin
  SiMain.LogScreenshot('Desktop Screenshot');
end;

end.
