<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>

        <v-data-table
          :headers="headers"
          :items="forecasts"
          hide-actions
          :loading="loading"
          class="elevation-1"
        >
          <v-progress-linear v-slot:progress color="blue" indeterminate></v-progress-linear>
          <template v-slot:items="props">
            <td>{{ props.item.dateFormatted }}</td>
            <td>{{ props.item.temperatureC }}</td>
            <td>{{ props.item.temperatureF }}</td>
            <td>{{ props.item.summary }}</td>
          </template>
        </v-data-table>

      </v-layout>
    </v-slide-y-transition>
      <v-alert
        :value="showError"
        type="error"
        v-text="errorMessage"
      >
        This is a error alert.
      </v-alert>
      <v-alert
        :value="showError"
        type="warning"
      >
        Are you sure you're using ASP.NET Core endpoint? (default at <a href="http://localhost:5000/fetch-data">http://localhost:5000</a>)<br>
        API call would fail with status code 404 when calling from Vue app (default at <a href="http://localhost:8080/fetch-data">http://localhost:8080</a>) without settings devServer proxy in vue.config.js file.
      </v-alert>      
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { Forecast } from '../models/Forecast';
import axios from 'axios';

@Component({})
export default class FetchDataView extends Vue {
  private loading: boolean = true;
  private showError: boolean = false;
  private errorMessage: string = 'Error while loading weather forecast.';
  private forecasts: Forecast[] = [];
  private headers = [
    { text: 'Date', value: 'dateFormatted' },
    { text: 'Temp. (C)', value: 'temperatureC' },
    { text: 'Temp. (F)', value: 'temperatureF' },
    { text: 'Summary', value: 'summary' },
  ];

  private created() {
    this.fetchWeatherForecasts();
  }

  private fetchWeatherForecasts() {
    axios
      .get<Forecast[]>('api/SampleData/WeatherForecasts')
      .then((response) => {
        this.forecasts = response.data;
      })
      .catch((e) => {
        this.showError = true;
        this.errorMessage = `Error while loading weather forecast: ${e.message}.`;
      })
      .finally(() => (this.loading = false));
  }
}
</script>
