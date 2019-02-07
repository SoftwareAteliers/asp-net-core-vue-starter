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
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { Forecast } from '../models/Forecast';
import axios from 'axios';

@Component({})
export default class FetchDataView extends Vue {
  private loading: boolean = true;
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
    axios.get<Forecast[]>('api/SampleData/WeatherForecasts')
      .then((response) => {
        this.forecasts = response.data;
        this.loading = false;
      });
  }
}
</script>
