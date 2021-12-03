package apiConnection;

import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonParser;
import models.Costumer;
import org.json.JSONObject;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class ApiService implements IApiService
{
    public static final String API_URL = "https://localhost:5003/Customers";//"https://localhost:5003/Customers"
    Gson gson = new Gson();
    HttpClient client;

    public ApiService()
    {
        client = HttpClient.newHttpClient();
    }

    @Override
    public synchronized String Register(Costumer costumer) throws IOException, InterruptedException
    {
        String costumerGson = gson.toJson(costumer);
        System.out.println(costumerGson);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(costumerGson))
                .build();

        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.statusCode());
        System.out.println(response.body());

        return String.valueOf(response.statusCode());
    }

    @Override
    public String Login(Costumer costumer) throws IOException, InterruptedException
    {
        String costumerJson = gson.toJson(costumer);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL+"/Login"))
                .POST(HttpRequest.BodyPublishers.ofString(costumerJson))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONObject object = new JSONObject(response.body().toString());
        System.out.println(object.getJSONObject("result"));

        return String.valueOf(object.getJSONObject("result"));
    }

    @Override
    public synchronized JsonArray GetAllCostumers() throws IOException, InterruptedException
    {
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(API_URL))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JsonParser jsonParser = new JsonParser();
        JsonArray jsonArray = (JsonArray) jsonParser.parse(response.body());

        System.out.println(jsonArray.toString());
        return jsonArray;
    }

    @Override
    public Costumer GetCostumerByUsername(String username) throws IOException, InterruptedException
    {
        return null;
    }

    @Override
    public String EditCostumer(Costumer costumer) throws IOException, InterruptedException
    {
        String costumerJson = gson.toJson(costumer);

        System.out.println(costumerJson);
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL+"/EditCustomer"))
                .method("PATCH", HttpRequest.BodyPublishers.ofString(costumerJson))
                .header("Content-Type", "application/json")
                .build();

        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONObject object = new JSONObject(response.body().toString());

        return String.valueOf(object.getJSONObject("result"));
    }

    @Override
    public String Logout(Costumer costumer) throws IOException, InterruptedException
    {
        String costumerJson = gson.toJson(costumer);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL+"/Logout"))
                .POST(HttpRequest.BodyPublishers.ofString(costumerJson))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONObject object = new JSONObject(response.body().toString());
        System.out.println(object.getJSONObject("result"));

        return String.valueOf(object.getJSONObject("result"));
    }
}