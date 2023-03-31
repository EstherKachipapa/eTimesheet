<template>
  <main>
    <div class="container">
      <div class="datetime">
        <div id="time"></div>
        <div id="date"></div>
      </div>
    </div>
    <div>
      <b-alert show variant="secondary">Day</b-alert>
      <b-alert show variant="success">Week</b-alert>
      <b-alert show variant="danger">Month</b-alert>
      <b-alert show variant="warning">Year</b-alert>
      <b-alert show variant="info">Projects</b-alert>
    </div>
    <b-calendar block locale="en-US"></b-calendar>
  </main>
</template>

<style>    .datetime {
      font-size: 16px;
      padding: 24px;
      margin-top: 30px;
      color: #ffff;
      background: #EEE;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.25);
      border-radius: 4px;
      border-right: 10px #009578 solid;
      width: 400px;
      font-family: sans-serif;
      font-weight: 500;
    }

    .container {
      margin: 0;
    }

    #time {
      font-size: 3em;
      color: #29C69F;
    }

    #date {
      margin-top: 12px;
      font-size: 1.75em;
      color: #444;
    }
</style>

<script>
export default {
  mounted() {
    const theTime = document.getElementById('time');
    const theDate = document.getElementById('date');

    setInterval(() => {
      const now = new Date();
      theTime.textContent = this.formatTime(now);
      theDate.textContent = this.formatDate(now);
    }, 200)
  },
  methods: {
    /**
     * @param {Date} date
     * */
    formatTime: function (date) {
      const hours12 = date.getHours() % 12 || 12;
      const minutes = date.getMinutes();

      return `${hours12}:${minutes}`;
    },
    formatDate: function (date) {
      const DAYS = [
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday"
      ];
      const MONTHS = [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
      ];

      return `${DAYS[date.getDay()]}, ${MONTHS[date.getMonth()]
        } ${date.getDate()} ${date.getFullYear()}`;
    }
  }
};
</script>