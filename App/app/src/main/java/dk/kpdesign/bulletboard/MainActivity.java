package dk.kpdesign.bulletboard;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.hardware.camera2.CameraDevice;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {


    ImageView imageView;
    MenuItem cameraButton;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        Toolbar toolbar = findViewById(R.id.customToolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle("Bulletboard");

        imageView = findViewById(R.id.image_review);
        cameraButton = findViewById(R.id.action_camera);


        //Requesting camera runtime permission
        if (ContextCompat.checkSelfPermission(MainActivity.this, Manifest.permission.CAMERA)
        != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(MainActivity.this, new String[]{
                Manifest.permission.CAMERA
            }, 100);
        }


    }






    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.toolbar_menu, menu);
        return true;
    }


    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_camera:
                item.setOnMenuItemClickListener( new MenuItem.OnMenuItemClickListener(){
                    @Override
                    public boolean onMenuItemClick(MenuItem item) {
                        Intent intent = new Intent("android.media.action.IMAGE_CAPTURE");
                        startActivity(intent);
                        return true;
                    }
                });
            case R.id.order_images:
                displayInfo("orderImages is selected");
                return true;
            case R.id.bullet_board:
                displayInfo("Bulletboard is selected");
                return true;
            case R.id.clear_all:
                displayInfo("ClearAll is selected");
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    public void displayInfo(String message) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }


    public void openCamera(CameraDevice cameraDevice) {

    }




/*    @Override
    protected void setOnClickListener(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // By ID we can get each component which id is assigned in XML file get Buttons and imageview.
        Object camera_open_id = findViewById(R.id.action_camera);
        Object click_image_id = findViewById(R.id.image_review);

        // Camera_open button is for open the camera and add the setOnClickListener in this button
        camera_open_id.setOnClickListener(v -> {
            // Create the camera_intent ACTION_IMAGE_CAPTURE it will open the camera for capture the image
            Intent camera_intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
            // Start the activity with camera_intent, and request pic id
            registerForActivityResult(camera_intent, pic_id);
        });
    }


    // This method will help to retrieve the image
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        // Match the request 'pic id with requestCode
        if (requestCode == pic_id) {
            // BitMap is data structure of image file which store the image in memory
            Bitmap photo = (Bitmap) data.getExtras().get("data");
            // Set the image in imageview for display
            click_image_id.setImageBitmap(photo);
        }
    }*/


}