package com.example.lab5_q4;

import java.io.InputStream;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.webkit.WebView;

public class MainActivity extends Activity {
	WebView webView;
	
	//Button screenshotButton;
	
	//private static final int REQUEST_CODE = 1;
	
	private static final String NAMESPACE = "http://tempuri.org/";
	private static String URL;   
	 private static String METHOD_NAME;
	 InputStream is =null;
	  
	
	// private Bitmap bitmap;
	
	//ImageView imageview;
	
	 String pathForAppFiles;
	

    /** Called when the activity is first created. */
  /*  @Override
    public void onCreate(Bundle savedInstanceState) {
    	
    	super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
    	webView = (WebView) findViewById(R.id.webView1);
    	screenshotButton = (Button)findViewById(R.id.button1);
    	imageview = (ImageView)findViewById(R.id.imageView1);
		webView.getSettings().setJavaScriptEnabled(true);
		
		webView.setBackgroundColor(0);
		
		webView.loadUrl("your-web-site-URL");
		
		
			screenshotButton.setOnClickListener(new OnClickListener() {
		        	 
		  		  public void onClick(View arg0) {
		  			GetandSaveCurrentImage();
		  		  }
		   
		  		});
        
    }*/

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		webView = (WebView) findViewById(R.id.webView1);
		webView.getSettings().setJavaScriptEnabled(true);
		
		webView.setBackgroundColor(0);
		
		webView.loadUrl("file:///android_asset/www/Assign_Q1_Q2.html");
		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

}
