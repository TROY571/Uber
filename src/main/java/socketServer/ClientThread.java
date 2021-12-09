package socketServer;

import apiConnection.ApiCustomerService;
import apiConnection.ApiDriverService;
import apiConnection.IApiCustomerService;
import apiConnection.IApiDriverService;
import com.google.gson.Gson;
import models.Costumer;
import models.Order;
import models.Request;
import org.json.JSONObject;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class ClientThread extends Thread
{
    private static Socket socket;
    private Gson gson;
    private IApiCustomerService apiCustomerService;
    private IApiDriverService apiDriverService;

    public ClientThread(Socket socket)
    {
        this.socket = socket;
        gson = new Gson();
        apiCustomerService = new ApiCustomerService();
        apiDriverService = new ApiDriverService();
        System.out.println("Connection started");
    }

    public void StartThread()
    {
        try
        {
            String json = "";
            InputStream in = socket.getInputStream();
            OutputStream out = socket.getOutputStream();


            byte[] byteStream = new byte[1024];
            System.out.println("im in the connection");
            int byteCount ;


            while(true)
            {
                while((byteCount =  in.read(byteStream)) != 0)
                {
                    json = new String(byteStream, 0, byteCount);
                    break;
                }
                System.out.println(json);

                JSONObject jsonObject = new JSONObject(json);
                Request request = new Request((String)jsonObject.get("Type"), jsonObject.get("Body"));
                System.out.println(request.toString());

                if(request.getType().equals("register"))
                {
                    Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                    System.out.println(costumer.toString());
                    String apiResponse = apiCustomerService.Register(costumer);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("login"))
                {
                    Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                    Costumer costumerTemp = new Costumer(costumer.getUsername(), costumer.getPassword());
                    System.out.println(costumer.toString());
                    String apiResponse = apiCustomerService.Login(costumerTemp);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("logout"))
                {
                    Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                    Costumer costumerTemp = new Costumer(costumer.getUsername(), costumer.getPassword());
                    System.out.println(costumer.toString());
                    String apiResponse = apiCustomerService.Logout(costumerTemp);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("edit"))
                {
                    Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                    String apiResponse = apiCustomerService.EditCostumer(costumer);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("order"))
                {
                    Order order = gson.fromJson(request.getBody().toString(), Order.class);
                    String apiResponse = apiCustomerService.RequestOrder(order);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}