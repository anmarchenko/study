// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "MultTopLevel.h"
#include "GraphDialog.h"
#include "MainFrm.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMainFrame

IMPLEMENT_DYNAMIC(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_WM_CREATE()
	ON_COMMAND(ID_FILE_CLOSE, &CMainFrame::OnFileClose)
	ON_WM_CLOSE()
	ON_WM_LBUTTONDOWN()
	ON_WM_SIZE()
	ON_WM_RBUTTONDOWN()
	ON_COMMAND(ID_GRAPHIC, &CMainFrame::OnGraphic)
	ON_WM_PAINT()
	ON_COMMAND(ID_PREFERENCES, &CMainFrame::OnPreferences)
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_X,
	ID_INDICATOR_Y,
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};


// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	// TODO: add member initialization code here
	chWnd=new CChildView();
	tools=new CToolDialog(this);
}

CMainFrame::~CMainFrame()
{
	delete chWnd;
	delete tools;
}


int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC	) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}


	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	chWnd->Create(NULL, NULL, WS_CHILD|WS_CLIPSIBLINGS|WS_CLIPCHILDREN, CRect(0, 0, 0,0),this, 100);
	chWnd->ShowWindow(SW_SHOW);
	// TODO: Delete these three lines if you don't want the toolbar to be dockable
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	EnableDocking(CBRS_ALIGN_RIGHT);
	DockControlBar(&m_wndToolBar,AFX_IDW_DOCKBAR_RIGHT );
	tools->Create(IDD_TOOLS, this);
	tools->ShowWindow(SW_SHOWNORMAL);

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	cs.style = WS_OVERLAPPED | WS_CAPTION | FWS_ADDTOTITLE
		 | WS_MINIMIZEBOX | WS_SYSMENU|WS_MAXIMIZEBOX|WS_CLIPCHILDREN;

	return TRUE;
}


// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}

#endif //_DEBUG


// CMainFrame message handlers



BOOL CMainFrame::LoadFrame(UINT nIDResource, DWORD dwDefaultStyle, CWnd* pParentWnd, CCreateContext* pContext) 
{
	// base class does the real work

	if (!CFrameWnd::LoadFrame(nIDResource, dwDefaultStyle, pParentWnd, pContext))
	{
		return FALSE;
	}

	CWinApp* pApp = AfxGetApp();
	if (pApp->m_pMainWnd == NULL)
		pApp->m_pMainWnd = this;

	return TRUE;
}

void CMainFrame::OnFileClose()
{
   DestroyWindow();
}

void CMainFrame::OnClose() 
{
	CFrameWnd::OnClose();
}

void CMainFrame::OnLButtonDown(UINT nFlags, CPoint point)
{
	// TODO: Add your message handler code here and/or call default
}

void CMainFrame::OnSize(UINT nType, int cx, int cy)
{
	CFrameWnd::OnSize(nType, cx, cy);
	CRect tmp;
	GetClientRect(&tmp);
	tools->MoveWindow(tmp.Height(), 0, tmp.Width()-tmp.Height()-30, tmp.Height()/5);
	tools->ShowWindow(SW_SHOW);
	// TODO: Add your message handler code here
}

void CMainFrame::SetCoord(CString chX, CString chY)
{
	m_wndStatusBar.SetPaneText(1, chX);
	m_wndStatusBar.SetPaneText(2, chY);
}

void CMainFrame::OnRButtonDown(UINT nFlags, CPoint point)
{
	// TODO: Add your message handler code here and/or call default
	CMenu pMenu;
	pMenu.LoadMenuA(IDR_MENUGRAPH);
	pMenu.GetSubMenu(0)->TrackPopupMenu(TPM_LEFTBUTTON, point.x, point.y, this);
	
	CFrameWnd::OnRButtonDown(nFlags, point);
}

void CMainFrame::OnGraphic()
{
	CGraphDialog graphDial(this);
	if (graphDial.DoModal()==IDOK){
		string tmp=const_cast<char*>(graphDial.m_Str.GetString());
		if (!baseGraph.addGraphic(tmp)){
			AfxMessageBox ("Invalid function! Try again.");
		}
		else{
			tools->ReInit();
		}
	}
	ChildReDraw();
}

void CMainFrame::OnPaint()
{
	CPaintDC dc(this); // device context for painting
	// TODO: Add your message handler code here
	// Do not call CFrameWnd::OnPaint() for painting messages
	tools->ShowWindow(SW_SHOW);
}

void CMainFrame::ChildReDraw(void)
{
	chWnd->Invalidate();
	chWnd->UpdateWindow();
}

void CMainFrame::OnPreferences()
{
	chWnd->OnPreferences();
}
